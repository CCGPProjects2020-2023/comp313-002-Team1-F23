/**Author's Name:          Ikamjot Hundal
 * Last Modified By:       Ikamjot Hundal
 * Date Last Modified:     December 4, 2023 
 * Description:            Displaying the results of the Level
 * ------------------------------------------------------------------------
 * Revision History:       December 4, 2023 (Ikamjot Hundal): Initial DisplayGameOverValues script.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayGameOverValues : MonoBehaviour
{
    [Header("Gameobjects that contains Text")]
    [SerializeField] private GameObject timeSurvivedGO;
    [SerializeField] private GameObject goldEarnedGO;
    [SerializeField] private GameObject levelReachedGO;
    [SerializeField] private GameObject enemiesDefeatedGO;


    private TextMeshProUGUI timeSurvivedText;
    private TextMeshPro goldEarnedText;
    private TextMeshPro levelReachedText;
    private TextMeshProUGUI enemiesDefeatedText;

    [Header("PlayePrefs")]
    [SerializeField] int enemiesKilled;
    [SerializeField] float maxTime;

    [Header("Outsider Scripts")]
    [SerializeField] PlayerHUDHandler playerHUDHandler;

    // Temporary Measure
    private void Awake()
    {
        if (PlayerPrefs.HasKey("EnemiesKilled") && PlayerPrefs.HasKey("MaxTime"))
        {
            enemiesKilled = PlayerPrefs.GetInt("EnemiesKilled");
            maxTime = PlayerPrefs.GetFloat("MaxTime");
        }
        else
        {
            PlayerPrefs.SetInt("EnemiesKilled", enemiesKilled);
            PlayerPrefs.SetFloat("MaxTime", maxTime);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // timeSurvivedText = timeSurvivedGO.GetComponent<TextMeshPro>();
        enemiesDefeatedGO = GameObject.Find("EnemiesTxt");
        enemiesDefeatedText = enemiesDefeatedGO.GetComponent<TextMeshProUGUI>();

        timeSurvivedGO = GameObject.Find("SurvivedTxt");
        timeSurvivedText = timeSurvivedGO.GetComponent<TextMeshProUGUI>();

        playerHUDHandler = playerHUDHandler.GetComponent<PlayerHUDHandler>();

        playerHUDHandler.DisplayTime(maxTime, timeSurvivedText);

        enemiesDefeatedText.text = "Enemies Defeated: " + enemiesKilled.ToString();

       

    }
}
