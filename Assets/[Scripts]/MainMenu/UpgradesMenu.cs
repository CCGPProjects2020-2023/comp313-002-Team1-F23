using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static Stats;

public class UpgradesMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
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
}
