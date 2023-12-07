using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static Stats;

public class UpgradesMenu : MonoBehaviour
{
    public TMP_Text text;
    // Update is called once per frame
    void Update()
    {
        text.text = GameController.Instance.gold.ToString();
    }

    public void UpgradeStat(string statName)
    {
        Stat stat;
        if (Enum.TryParse(statName, out stat))
        {
            GameController.Instance.UpdateStat(stat);
        }
        else
        {
            Debug.Log("Cannot find stat");
        }
    }

    public void ResetUpgrades()
    {
        foreach (Upgrade u in GameController.Instance.upgrades)
        {
            GameController.Instance.gold += u.currentLevel * u.gold;
            u.currentLevel = 0;
            u.UpdateLevel();
        }

        foreach (Stats s in GameController.Instance.playerStats)
        {
            s.value = 0;
        }
    }
}
