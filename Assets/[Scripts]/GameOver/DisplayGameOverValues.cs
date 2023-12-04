/**Author's Name:          Ikamjot Hundal
 * Last Modified By:       Ikamjot Hundal
 * Date Last Modified:     December 4, 2023 
 * Description:            Displaying the results of the Level
 * ------------------------------------------------------------------------
 * Revision History:       December 4, 2023 (Ikamjot Hundal): Initial Heart script.
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

    private TextMeshPro timeSurvivedText;
    private TextMeshPro goldEarnedText;
    private TextMeshPro levelReachedText;
    private TextMeshProUGUI enemiesDefeatedText;

    [SerializeField] int enemiesKilled;



    // Temporary Measure
    private void Awake()
    {
        if (PlayerPrefs.HasKey("EnemiesKilled"))
        {
            enemiesKilled = PlayerPrefs.GetInt("EnemiesKilled");
        }
        else
        {
            PlayerPrefs.SetInt("EnemiesKilled", enemiesKilled);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // timeSurvivedText = timeSurvivedGO.GetComponent<TextMeshPro>();
        enemiesDefeatedGO = GameObject.Find("EnemiesTxt");
        enemiesDefeatedText = enemiesDefeatedGO.GetComponent<TextMeshProUGUI>();

        enemiesDefeatedText.text = "Enemies Defeated: " + enemiesKilled.ToString();
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
