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
    private int currentGold = 10;

    public int enemiesKilledCounter = 0;

    private List<int> upgradeLevels;

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
        this.currentData.persistentUpgrades.gold = currentGold;
        this.currentData.persistentUpgrades.enemiesKillCounter = enemiesKilledCounter;

        SerializationController.Save(saveName, this.currentData);
        Debug.Log("Saved");
    }

    private void OnLoad(string saveName)
    {
        SaveData.currentData = (SaveData)SerializationController.Load(Application.persistentDataPath + "/spacesurvivor/" + saveName + ".xml");

        playerStats = SaveData.currentData.persistentUpgrades.playerStats;
        upgradeLevels = SaveData.currentData.persistentUpgrades.upgradeLevels;
        currentGold = SaveData.currentData.persistentUpgrades.gold;
        enemiesKilledCounter = SaveData.currentData.persistentUpgrades.enemiesKillCounter;

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
