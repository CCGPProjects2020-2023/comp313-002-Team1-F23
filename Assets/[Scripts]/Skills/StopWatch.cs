/* Author's Name:          Ikamjot Hundal
 * Last Modified By:       Ikamjot Hundal
 * Date Last Modified:     November 1st, 2023 
 * Description:            Child Class to TEMP_Buff.cs for managing Cooldown Rate
 * ------------------------------------------------------------------------
 * Revision History:       October 26th, 2023: Initial StopWatch script.
 *                         October 28th, 2023: Updated the script to be the child of TEMP_Buff
 *                         October 30th 2023: Changed to override method
 *                         November 1st, 2023: Setting the BuffType
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : TEMP_Buff
{
    [SerializeField] private float initialCooldownRate = 2f;
    [SerializeField] private float decreaseCooldownRate = 0.5f;

    public new BuffType Type { private get; set; }

    public StopWatch(BuffType type, int maxLevel) : base(type, maxLevel)
    {
        type = BuffType.Stopwatch;
        Type = type;
    }

    public override void ApplyBuff()
    {
        if (initialCooldownRate > 0)
        {
            initialCooldownRate -= decreaseCooldownRate + Time.deltaTime;
            Debug.Log(initialCooldownRate);
        }
        else
        {
            Debug.Log("huh uh");
        }
    }
}
