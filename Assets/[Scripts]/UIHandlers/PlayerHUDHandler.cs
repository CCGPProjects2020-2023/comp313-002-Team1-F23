/**Author's Name:          Ikamjot Hundal
 * Last Modified By:       Ikamjot Hundal
 * Date Last Modified:     December 5, 2023 
 * Description:            Displaying the results of the Level
 * ------------------------------------------------------------------------
 * Revision History:       December 4, 2023 (Ikamjot Hundal): Initial PlayerHUDHandler script.
 *                         December 5, 2023 (Ikamjot Hundal): Added Levels, Enemies, and Gold related features.  
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

    [SerializeField] GameObject goldAmountGO;
    TextMeshProUGUI goldAmountText;


    [Header("Altering the Time ")]
    [SerializeField] private float timeElapsed = 0;
    [SerializeField] private bool timeRunning = false;
    [Header("Multiply by 100")]
    [SerializeField] private float maxTime = 600f;

    private int enemiesKilled;
    private float timeResult;
    private int inGamelevel;
    private float inGameGold;


    // Temporary Measure
    private void Awake()
    {
        if (PlayerPrefs.HasKey("EnemiesKilled") && PlayerPrefs.HasKey("MaxTime") && PlayerPrefs.HasKey("MaxLevel") && PlayerPrefs.HasKey("InGameGold"))
        {
            enemiesKilled = PlayerPrefs.GetInt("EnemiesKilled");
            timeResult = PlayerPrefs.GetFloat("MaxTime");
            inGamelevel = PlayerPrefs.GetInt("MaxLevel");
            inGameGold = PlayerPrefs.GetFloat("InGameGold");
        }
        else
        {
            PlayerPrefs.SetInt("EnemiesKilled", enemiesKilled);
            PlayerPrefs.SetFloat("MaxTime", timeResult);
            PlayerPrefs.SetInt("MaxLevel", inGamelevel);
            PlayerPrefs.SetFloat("InGameGold", inGameGold);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timerText = timerTextGO.GetComponent<TextMeshProUGUI>();
        enemiesText = enemiesTextGO.GetComponent<TextMeshProUGUI>();
        levelText = levelTextGO.GetComponent<TextMeshProUGUI>();
        goldAmountText = goldAmountGO.GetComponent<TextMeshProUGUI>();

        enemiesText.text = "Enemies Killed: " + enemiesKilled.ToString();

        DisplayTime(timeResult, timerText);

        levelText.text = "LVL: " + inGamelevel.ToString();
        goldAmountText.text = "GOLD: " + inGameGold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timeRunning == true)
        {
            //string levelTextString = ExperienceManager.Instance.Level.ToString();
            if (timeElapsed <= maxTime)
            {
                timeElapsed += Time.deltaTime;
                PlayerPrefs.SetFloat("MaxTime", timeElapsed);
                DisplayTime(timeElapsed, timerText);

                enemiesText.text = $"Enemies Killed: {GameController.Instance.enemiesKilledCounter}";

                levelBar.fillAmount = (ExperienceManager.Instance.CalculateCurrentExperienceInCurrentLevel() / ExperienceManager.Instance.CalculateRequiredExperienceForNextLevel());

                levelText.text = $"LVL: {ExperienceManager.Instance.Level}";
                PlayerPrefs.SetInt("MaxLevel", ExperienceManager.Instance.Level);
                goldAmountText.text = $"GOLD: {GameController.Instance.inGameGold}";

            }
            else
            {
                timeElapsed = maxTime;
                enemiesText.text = $"Enemies Killed: {GameController.Instance.enemiesKilledCounter}";
                levelText.text = $"LVL: {ExperienceManager.Instance.Level}";
                goldAmountText.text = $"GOLD: {GameController.Instance.inGameGold}";
                PlayerPrefs.SetFloat("MaxTime", timeElapsed);
                PlayerPrefs.SetFloat("InGameGold", inGameGold);
                SceneManager.LoadScene("GameOver");
            }
        }
        // 
    }

    public void DisplayTime(float timerDisplay, TextMeshProUGUI timerText)
    {
        float minutes = Mathf.FloorToInt(timerDisplay / 60);
        float seconds = Mathf.FloorToInt(timerDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
