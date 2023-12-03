/** Author's Name:          Sukhmannat Singh
 *  Last Modified By:       Sukhmannat Singh
 *  Date Last Modified:     November 3, 2023
 *  Program Description:    A Controller for the game.
 *  Revision History:       November 3, 2023 (Sukhmannat Singh): Initial GameController script.
 */

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Stats;

public class GameController : Singleton<GameController>
{
    public List<Stats> playerStats;
    public List<Upgrade> upgrades;
    [HideInInspector]public SaveData currentData;
    private int currentGold = 10;

    private List<int> upgradeLevels;

    void Start()
    {
        OnLoad("Save 1");
    }

    public void UpdateStat(Stat stat)
    {
        switch (stat)
        {
            case Stat.Damage:
                playerStats.Find(x => x.stat == stat).value += 5;
                break;
            case Stat.Health:
                playerStats.Find(x => x.stat == stat).value += 10;
                break;
            case Stat.Armor:
                playerStats.Find(x => x.stat == stat).value += 5;
                break;
            case Stat.MoveSpeed:
                playerStats.Find(x => x.stat == stat).value += 1;
                break;
        }

        for (int i = 0; i< playerStats.Count; i++)
        {
            if (playerStats[i].value >= playerStats[i].maxValue)
            {
                playerStats[i].value = playerStats[i].maxValue;
            }
        }
    }

    private void GetUpgradeLevels()
    {
        upgradeLevels.Clear();
        foreach(Upgrade u in upgrades)
        {
            upgradeLevels.Add(u.currentLevel);
        }
    }

    private void SetUpgradeLevels(List<int> list)
    {
        for (int i = 0; i < upgradeLevels.Count; i++)
        {
            upgrades[i].currentLevel = upgradeLevels[i];
            upgrades[i].UpdateLevel();
        }
    }

    public void OnSave(string saveName)
    {
        GetUpgradeLevels();

        this.currentData.persistentUpgrades.playerStats = playerStats;
        this.currentData.persistentUpgrades.upgradeLevels = upgradeLevels;
        this.currentData.persistentUpgrades.gold = currentGold;

        SerializationController.Save(saveName, this.currentData);
        Debug.Log("Saved");
    }

    private void OnLoad(string saveName)
    {
        SaveData.currentData = (SaveData) SerializationController.Load(Application.persistentDataPath + "/spacesurvivor/" + saveName + ".xml");
        
        playerStats = SaveData.currentData.persistentUpgrades.playerStats;
        upgradeLevels = SaveData.currentData.persistentUpgrades.upgradeLevels;
        currentGold = SaveData.currentData.persistentUpgrades.gold;

        SetUpgradeLevels(upgradeLevels);
        Debug.Log("Loaded");
    }
}
