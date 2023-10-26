/* Author's Name: Ikamjot Hundal
 * Created On: October 26, 2023
 * Last Modified By: Ikamjot Hundal
 * Date Last Modified: October 26, 2023 
 * Description: Child Class to TEMP_Buff.cs for managing Cooldown Rate
 * Revision History: October 26, 2023: Initial RedTarget script.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTarget : MonoBehaviour
{
    [SerializeField] private float initalDamageRate = 10f;
    [SerializeField] private float increasedDamageRate = 5f;

    public void IncreaseDamage()
    {
        initalDamageRate += increasedDamageRate;
    }
}
