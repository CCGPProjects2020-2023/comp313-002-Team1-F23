using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    public int currentLevel, maxLevel;
    public float gold;
    public TMP_Text text;
    public UpgradesMenu upgradesMenu;

    public void IncreaseLevel(string stat)
    {
        if (GameController.Instance.gold >= gold && currentLevel < maxLevel)
        {
            GameController.Instance.gold -= gold;
            currentLevel += 1;
            upgradesMenu.UpgradeStat(stat);
            UpdateLevel();
        }
    }

    public void UpdateLevel()
    {
        if (currentLevel > maxLevel)
        {
            currentLevel = maxLevel;
        }
        text.text = currentLevel + "/" + maxLevel;
    }
}
