/* Author's Name: Ikamjot Hundal
 * Created On: October 30, 2023
 * Last Modified By: Ikamjot Hundal
 * Date Last Modified: October 26, 2023 
 * Description: Child Class to TEMP_Buff.cs for managing Health
 * Revision History: October 26, 2023: Initial Heart script.
 *                   October 28, 2023: Updated the script to be the child of TEMP_Buff
 *                   October 30th 2023: Changed to override method
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : TEMP_Buff
{
    [SerializeField] private float playerHealth = 100;
    [SerializeField] private float increaseHealthPercentage = 0.5f;

    public Heart(BuffType type, int maxLevel) : base(type, maxLevel)
    {

    }

    public override void ApplyBuff()
    {
        playerHealth += increaseHealthPercentage;
        Debug.Log(playerHealth);
    }
}
