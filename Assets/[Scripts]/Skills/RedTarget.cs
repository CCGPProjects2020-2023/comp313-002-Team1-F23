/* Author's Name:          Ikamjot Hundal
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

public class RedTarget : TEMP_Buff
{
    [SerializeField] private float initalDamageRate = 10f;
    [SerializeField] private float increasedDamageRate = 5f;

    public new BuffType Type { private get; set; }

    public RedTarget(BuffType type, int maxLevel) : base(type, maxLevel)
    {
        type = BuffType.RedTarget;
        Type = type;
    }

    public override void ApplyBuff()
    {
        initalDamageRate += increasedDamageRate;
        Debug.Log(initalDamageRate);
    }
}
