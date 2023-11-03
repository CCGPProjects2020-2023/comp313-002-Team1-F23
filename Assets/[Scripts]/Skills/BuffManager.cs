using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    // get the instance of HealthManager

    // get instance of ExperienceManager 
    public ExperienceManager experienceManager;

    // get the instance of LevelManager?
    // temp
    public static int currentLevel;

    public static BuffType buffType;
    

    // Get the instance of the TEMPBuff?
    public TEMP_Buff buff = new TEMP_Buff(buffType, currentLevel);

    // or the child classes?
    Heart heartInstance = new Heart(buffType, currentLevel); 
    RedTarget redTargetInstance = new RedTarget(buffType, currentLevel); 
    StopWatch stopWatchInstance = new StopWatch(buffType, currentLevel);

    private void Start()
    {
        experienceManager.Level = currentLevel;
    }



    private void Update()
    {
        if (experienceManager.IsLevellingUp == true)
        {
            ManageBuffs();
        }
    }


    public void ManageBuffs()
    {
        if (buffType == BuffType.Heart)
        {
            heartInstance.ApplyBuff();
        }
        else if (buffType == BuffType.RedTarget)
        {
            redTargetInstance.ApplyBuff();
        }
        else if (buffType == BuffType.Stopwatch)
        {
            stopWatchInstance.ApplyBuff();
        }
    }
}
