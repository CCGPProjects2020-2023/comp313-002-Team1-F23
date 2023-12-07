/** Author's Name:          Sukhmannat Singh
 *  Last Modified By:       Ikamjot Hundal
 *  Date Last Modified:     December 3, 2023
 *  Program Description:    A Controller for the game.
 *  Revision History:       November 3, 2023 (Sukhmannat Singh): Initial GameController script.
 *                          December 3, 2023 (Ikamjot Hundal): Added a method to add to enemyKillCounter
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Stats;

public class GameController : Singleton<GameController>
{
    public List<Stats> playerStats;
    public List<Upgrade> upgrades;
    [HideInInspector] public SaveData currentData;
    public float gold;

    public float inGameGold = 0;

    public int enemiesKilledCounter = 0;

    public List<int> upgradeLevels;

    void Start()
    {
        if (ExperienceManager.Instance != null)
        {
            ExperienceManager.Instance.ExperienceThresholdReached += OnExperienceThresholdReached;
        }
        if (LevelUpWindowPresenter.Instance != null)
        {
            LevelUpWindowPresenter.Instance.SkillToLevelUpSelected += OnSkillToLevelUpSelected;
        }
        upgradeLevels = new List<int>();
        OnLoad("Save 1");
    }
    private void OnDestroy()
    {
        if (ExperienceManager.Instance != null)
        {
            ExperienceManager.Instance.ExperienceThresholdReached -= OnExperienceThresholdReached;
        }
        if (LevelUpWindowPresenter.Instance != null)
        {
            LevelUpWindowPresenter.Instance.SkillToLevelUpSelected -= OnSkillToLevelUpSelected;
        }
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
            case Stat.GoldGain:
                playerStats.Find(x => x.stat == stat).value += 1;
                break;
        }

        for (int i = 0; i < playerStats.Count; i++)
        {
            if (playerStats[i].value >= playerStats[i].maxValue)
            {
                playerStats[i].value = playerStats[i].maxValue;
            }
        }
    }

    public void AddtoEnemyCounter()
    {
        enemiesKilledCounter++;
    }
    public void PauseTime()
    {
        Time.timeScale = 0;
    }
    public void ResumeTime()
    {
        Time.timeScale = 1;
    }
    public void GetUpgradeLevels()
    {
        upgradeLevels.Clear();
        foreach (Upgrade u in upgrades)
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
        this.currentData.persistentUpgrades.gold = gold;
        SerializationController.Save(saveName, this.currentData);
        Debug.Log("Saved");
    }
    public void SaveGold(string saveName)
    {
        this.currentData.persistentUpgrades.playerStats = playerStats;
        this.currentData.persistentUpgrades.upgradeLevels = upgradeLevels;
        this.currentData.persistentUpgrades.gold = gold;
        SerializationController.Save(saveName, this.currentData);
        Debug.Log("Saved");
    }

    private void OnLoad(string saveName)
    {
        SaveData.currentData = (SaveData)SerializationController.Load(Application.persistentDataPath + "/spacesurvivor/" + saveName + ".xml");

        playerStats = SaveData.currentData.persistentUpgrades.playerStats;
        upgradeLevels = SaveData.currentData.persistentUpgrades.upgradeLevels;
        gold = SaveData.currentData.persistentUpgrades.gold;

        SetUpgradeLevels(upgradeLevels);
        Debug.Log("Loaded");
    }
    private void OnExperienceThresholdReached()
    {
        PauseTime();
    }
    private void OnSkillToLevelUpSelected()
    {
        ResumeTime();
    }
}
