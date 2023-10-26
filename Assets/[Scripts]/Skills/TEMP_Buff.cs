/*  Author's Name:          Marcus Ngooi
 *  Last Modified By:       Ikamjot Hundal
 *  Date Last Modified:     October 26, 2023
 *  Program Description:    Manages experience in the game.
 *  Revision History:       October 26, 2023: Initial TEMP_Buff script.
 *                          October 26, 2023: Added features for dealing with child classes
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP_Buff : MonoBehaviour
{
    public enum BuffType
    {
        Heart,
        RedTarget,
        Stopwatch
    };
    private string description = "";
    private int currentLevel = 0;
    private int maxLevel = 0;

    //BuffType buffSelected;

    [SerializeField] private bool isHeartSelected = false;
    [SerializeField] private bool isRedTargetSelected = false;
    [SerializeField] private bool isStopwatchSelected = false;


    // Calling the "child" classes
    Heart heart;
    RedTarget redTarget;
    StopWatch stopwatch;




    // Start is called before the first frame update
    void Start()
    {
        heart = GetComponent<Heart>();
        redTarget = GetComponent<RedTarget>();
        stopwatch = GetComponent<StopWatch>();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyBuff();
    }

    // this hurts me. There should be better method than this.
    public void ApplyBuff()
    {
        if (!isHeartSelected)
        {
            for (int i = 0; i < 3; i++)
            {
                heart.IncreaseHealth();
                i++;
            }
        }
        if (!isRedTargetSelected)
        {
            for (int i = 0; i < 3; i++)
            {
                redTarget.IncreaseDamage();
                i++;
            }
        }
        if (!isStopwatchSelected)
        {
            for (int i = 0; i < 3; i++)
            {
                stopwatch.DecreaseCoolDown();
                i++;
            }
        }
    }

    public bool IsMaxLevel()
    {
        return currentLevel >= maxLevel;
    }
}
