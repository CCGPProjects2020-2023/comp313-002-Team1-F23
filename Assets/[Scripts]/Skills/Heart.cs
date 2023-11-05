/**Author's Name:          Ikamjot Hundal
 * Last Modified By:       Ikamjot Hundal
 * Date Last Modified:     November 1st, 2023 
 * Description:            Child Class to TEMP_Buff.cs for managing Health
 * ------------------------------------------------------------------------
 * Revision History:       October 26th, 2023: Initial Heart script.
 *                         October 28th, 2023: Updated the script to be the child of TEMP_Buff
 *                         October 30th 2023: Changed to override method
 *                         November 1st, 2023: Setting the BuffType
 */
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Heart : Buff
{
    [Header("Do it in point form-- lower-- the higher number is")]
    [SerializeField] private float increaseHealthPercentage = 10f;

    [SerializeField] TEMP_HealthManager healthManager;

   // public int currentLevel = 3; 




    private void Start()
    {
        buffType = BuffType.Heart;
    }

    // health percentage varies based on the level
    // current maxHealth, newMaxHealth,
    // Create new script (Monobehaviour) to say "yo, there are variables being modified," pls remember it  
    // 
    public override void ApplyBuff()
    {

        //float tempAdditionalHealth =
 
        TEMP_HealthManager.Instance.additionalHealth = currentLevel * increaseHealthPercentage / 100 * TEMP_HealthManager.Instance.basePlayerHealth;

        Debug.Log("Additional Health: " + TEMP_HealthManager.Instance.additionalHealth);
    }
}
