/* Author's Name: Ikamjot Hundal
 * Created On: October 26, 2023
 * Last Modified By: Ikamjot Hundal
 * Date Last Modified: October 26, 2023 
 * Description: Child Class to TEMP_Buff.cs for managing Cooldown Rate
 * Revision History: October 26, 2023: Initial StopWatch script.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : MonoBehaviour
{
    [SerializeField] private float initialCooldownRate = 2f;
    [SerializeField] private float decreaseCooldownRate = 0.5f;


    public void DecreaseCoolDown()
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
