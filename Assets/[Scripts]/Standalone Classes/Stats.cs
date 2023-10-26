/* Author's Name: Sukhmannat Singh 
 * Created On: October 10, 2023
 * Last Modified By: Ikamjot Hundal
 * Date Last Modified: October 25, 2023 
 * Description: Serves as a enum in managing the stats.
 * Revision History: October 10, 2023: Initial Stats Script
 *                   October 25, 2023: Added number to variable value 
 *                   October 26, 2023: Reset the script to original state
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    public enum Stat
    {
        Damage,
        Health,
        Armor,
        MoveSpeed,
        GoldGain,
        PickupRange,
        Luck
    }

    public Stat stat;
    public float value;
}
