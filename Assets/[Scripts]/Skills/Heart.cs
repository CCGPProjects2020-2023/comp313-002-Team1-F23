/* Author's Name:          Ikamjot Hundal
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
    [SerializeField] private float tempPlayerHealth = 100;
    [SerializeField] private float increaseHealthPercentage = 0.5f;



    public TEMP_HealthManager healthManager = new();

    public BuffType buffType;

    //public BuffType heartType { get; set; }
    public Heart(BuffType type, int maxLevel) : base(BuffType.Heart, maxLevel)
    {
        this.buffType = type;
    }

    // health percentage varies based on the level
    // current maxHealth, newMaxHealth,
    // Create new script (Monobehaviour) to say "yo, there are variables being modified," pls remember it  
    // 
    public override void ApplyBuff()
    {

        // tempPlayerHealth 
        float tempPlayerHealth = healthManager.maxPlayerHealth;
        Debug.Log(tempPlayerHealth);

        increaseHealthPercentage = (tempPlayerHealth / increaseHealthPercentage);

        tempPlayerHealth += increaseHealthPercentage;

        healthManager.maxPlayerHealth = tempPlayerHealth;
        Debug.Log(healthManager.maxPlayerHealth);
    }
}
