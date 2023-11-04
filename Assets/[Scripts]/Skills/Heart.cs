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

    [SerializeField] private float increaseHealthPercentage = 10f;

    [SerializeField] TEMP_HealthManager healthManager;

    private void Start()
    {
        buffType = BuffType.Heart;
    }

    // Additional Health varies based on the level
    // Example: 3 * (10/100) * 100 = 30
    public override void ApplyBuff()
    {

        Debug.Log("Original Base Health: " + TEMP_HealthManager.Instance.basePlayerHealth);
 
        TEMP_HealthManager.Instance.additionalHealth = currentLevel * increaseHealthPercentage / 100 * TEMP_HealthManager.Instance.basePlayerHealth;

        Debug.Log("Additional Health: " + TEMP_HealthManager.Instance.additionalHealth);
        Debug.Log("Updated Base Health: " 
            + (TEMP_HealthManager.Instance.basePlayerHealth + TEMP_HealthManager.Instance.additionalHealth));

    }
}
