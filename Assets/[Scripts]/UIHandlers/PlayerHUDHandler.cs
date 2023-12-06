/**Author's Name:          Ikamjot Hundal
 * Last Modified By:       Ikamjot Hundal
 * Date Last Modified:     December 4, 2023 
 * Description:            Displaying the results of the Level
 * ------------------------------------------------------------------------
 * Revision History:       December 4, 2023 (Ikamjot Hundal): Initial PlayerHUDHandler script.
 *                         December 5, 2023 (Ikamjot Hundal):
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerHUDHandler : MonoBehaviour
{
    
    [SerializeField] GameObject timerTextGO;
    TextMeshProUGUI timerText;

    [SerializeField] GameObject enemiesTextGO;
    TextMeshProUGUI enemiesText;

    [SerializeField] GameObject levelTextGO;
    TextMeshProUGUI levelText;

    [SerializeField] Image levelBar;

    [SerializeField] float levelAmount; 

    [Header("Altering the Time ")]
    [SerializeField] private float timeElapsed = 0;
    [SerializeField] private bool timeRunning = false;
    [Header("Multiply by 100")]
    [SerializeField] private float maxTime = 600f;

    private int enemiesKilled;
    private float timeResult;
    private int inGamelevel; 



    // Temporary Measure
    private void Awake()
    {
        if (PlayerPrefs.HasKey("EnemiesKilled") && PlayerPrefs.HasKey("MaxTime") && PlayerPrefs.HasKey("MaxLevel"))
        {
            enemiesKilled = PlayerPrefs.GetInt("EnemiesKilled");
            timeResult = PlayerPrefs.GetFloat("MaxTime");
            inGamelevel = PlayerPrefs.GetInt("MaxLevel");
        }
        else
        {
            PlayerPrefs.SetInt("EnemiesKilled", enemiesKilled);
            PlayerPrefs.SetFloat("MaxTime", timeResult);
            PlayerPrefs.SetInt("MaxLevel", inGamelevel);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timerText = timerTextGO.GetComponent<TextMeshProUGUI>();
        enemiesText = enemiesTextGO.GetComponent<TextMeshProUGUI>();
        levelText = levelTextGO.GetComponent<TextMeshProUGUI>();


        enemiesText.text = "Enemies Killed: " + enemiesKilled.ToString();

        DisplayTime(timeResult, timerText);

        levelText.text = "LVL: " + inGamelevel.ToString();


    }

    // Update is called once per frame
    void Update()
    {
        string levelTextString = ExperienceManager.Instance.Level.ToString();
        if (timeRunning == true)
        {
            if (timeElapsed <= maxTime)
            {
                timeElapsed += Time.deltaTime;
                PlayerPrefs.SetFloat("MaxTime", timeElapsed);
                DisplayTime(timeElapsed, timerText);

                enemiesText.text = $"Enemies Killed: {GameController.Instance.enemiesKilledCounter}";

                levelBar.fillAmount = ExperienceManager.Instance.CalculateCurrentExperienceInCurrentLevel();

                levelText.text = $"LVL: {levelTextString}";


            }
            else
            {
                timeElapsed = maxTime;
                enemiesText.text = $"Enemies Killed: {GameController.Instance.enemiesKilledCounter}";
                levelText.text = $"LVL: {levelTextString}";
                PlayerPrefs.SetFloat("MaxTime", timeElapsed);
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    public void DisplayTime(float timerDisplay, TextMeshProUGUI timerText)
    {
        float minutes = Mathf.FloorToInt(timerDisplay / 60);
        float seconds = Mathf.FloorToInt(timerDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
