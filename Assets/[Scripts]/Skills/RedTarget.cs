/**Author's Name:          Ikamjot Hundal
 * Last Modified By:       Ikamjot Hundal
 * Date Last Modified:     November 1st, 2023 
 * Description:            Child Class to TEMP_Buff.cs for managing Cooldown Rate
 * ------------------------------------------------------------------------
 * Revision History:       October 26th, 2023: Initial RedTarget script.
 *                         October 28th, 2023: Updated the script to be the child of TEMP_Buff
 *                         October 30th 2023: Changed to override method
 *                         November 1st, 2023: Setting the BuffType
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTarget : Buff
{
    [SerializeField] private float initalDamageRate = 10f;
    [SerializeField] private float increasedDamageRate = 5f;

    [SerializeField] private TEMP_DamageManager damageManager;

   // [SerializeField] private int currentLevel = 3;

    private void Start()
    {
        buffType = BuffType.RedTarget;
    }

    public override void ApplyBuff()
    {
        
        TEMP_DamageManager.Instance.additionalDamage = currentLevel * increasedDamageRate * TEMP_DamageManager.Instance.baseDamage;

        Debug.Log("Additional Damage: " + TEMP_DamageManager.Instance.additionalDamage);
    }
}