/** Author's Name:          Sukhmannat Singh
 *  Last Modified By:       Sukhmannat Singh
 *  Date Last Modified:     November 3, 2023
 *  Program Description:    A Controller for the game.
 *  Revision History:       November 3, 2023 (Sukhmannat Singh): Initial GameController script.
 */

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance; //Singleton

    public List<Stats> playerStats; // [Subject to removal] (Should be in player controller)

    // Public variables
    [HideInInspector]public SaveData currentData;
    private int currentGold = 10; // [Subject to removal] (Should be handle by something else)

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        OnLoad("Save 1");
    }

    public void OnSave(string saveName)
    {
        this.currentData.persistentUpgrades.playerStats = playerStats;
        this.currentData.persistentUpgrades.gold = currentGold;

        SerializationController.Save(saveName, this.currentData);
        Debug.Log("Saved");
    }

    private void OnLoad(string saveName)
    {
        SaveData.currentData = (SaveData) SerializationController.Load(Application.persistentDataPath + "/spacesurvivor/" + saveName + ".xml");
        
        playerStats = SaveData.currentData.persistentUpgrades.playerStats;
        currentGold = SaveData.currentData.persistentUpgrades.gold;
        Debug.Log("Loaded");
    }
}
