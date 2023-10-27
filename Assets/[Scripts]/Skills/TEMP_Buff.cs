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
        None,
        Heart,
        RedTarget,
        Stopwatch
    };
    private string description = "";
    private int currentLevel = 0;
    private int maxLevel = 0;

    //BuffType buffSelected;

    //[SerializeField] private bool isHeartSelected = false;
    //[SerializeField] private bool isRedTargetSelected = false;
    //[SerializeField] private bool isStopwatchSelected = false;

    [SerializeField] private BuffType buffType;


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
        TestInput();
        ApplyBuff();
    }

    // this hurts me. There should be better method than this.
    public void ApplyBuff()
    {
        /*if (!isHeartSelected)
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
        } */

        if (buffType == BuffType.Heart)
        {
            Debug.Log("Increase Health");
            heart.IncreaseHealth();
            buffType = BuffType.None;
        }
        if (buffType == BuffType.RedTarget)
        {
            Debug.Log("Increase Damage");
            redTarget.IncreaseDamage();
            buffType = BuffType.None;
        }
        if (buffType == BuffType.Stopwatch)
        {
            Debug.Log("Reduce Cooldown");
            stopwatch.DecreaseCoolDown();
            buffType = BuffType.None;
        }
    }

    public bool IsMaxLevel()
    {
        return currentLevel >= maxLevel;
    }

    public void TestInput()
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            buffType = BuffType.Heart;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            buffType = BuffType.RedTarget;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            buffType= BuffType.Stopwatch;
        }
    }
}
