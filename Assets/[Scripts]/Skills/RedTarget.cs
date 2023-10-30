/* Author's Name: Ikamjot Hundal
 * Created On: October 30, 2023
 * Last Modified By: Ikamjot Hundal
 * Date Last Modified: October 26, 2023 
 * Description: Child Class to TEMP_Buff.cs for managing Cooldown Rate
 * Revision History: October 26, 2023: Initial RedTarget script.
 *                   October 30th 2023: Changed to override method
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTarget : TEMP_Buff
{
    [SerializeField] private float initalDamageRate = 10f;
    [SerializeField] private float increasedDamageRate = 5f;

    public RedTarget(BuffType type, int maxLevel) : base(type, maxLevel)
    {
    }

    public override void ApplyBuff()
    {
        initalDamageRate += increasedDamageRate;
        Debug.Log(initalDamageRate);
    }
}
