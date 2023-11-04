using System.Collections;
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

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            OnSave("Save 1");
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            OnLoad("Save 1");
        }
    }

    private void OnSave(string saveName)
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
