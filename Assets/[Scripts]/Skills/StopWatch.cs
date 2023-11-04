/* Author's Name:          Ikamjot Hundal
 * Last Modified By:       Ikamjot Hundal
 * Date Last Modified:     November 1st, 2023 
 * Description:            Child Class to TEMP_Buff.cs for managing Cooldown Rate
 * ------------------------------------------------------------------------
 * Revision History:       October 26th, 2023: Initial StopWatch script.
 *                         October 28th, 2023: Updated the script to be the child of TEMP_Buff
 *                         October 30th 2023: Changed to override method
 *                         November 1st, 2023: Setting the BuffType
 *                         November 3rd, 2023: Revamping the calucations 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : Buff
{
    [SerializeField] private float initialCooldownRate = 5f;
    [SerializeField] private float decreaseCooldownRate = 0.5f;

    // public BuffType stopWatchType { private get; set; }

    [SerializeField] private BuffType buffType;

    [SerializeField] TEMP_CoolDownManager coolDownManager;

    [SerializeField] private int currentLevel = 3;

    private void Start()
    {
        buffType = BuffType.Stopwatch;
    }

    public StopWatch(BuffType type, int maxLevel) : base(type, maxLevel)
    {
        this.buffType = type;
        
    }

    public override void ApplyBuff()
    {
        if (TEMP_CoolDownManager.Instance.coolDownReduction > 0)
        {
            Debug.Log(TEMP_CoolDownManager.Instance.coolDownReduction);
            //TEMP_CoolDownManager.Instance.baseCoolDown -= TEMP_CoolDownManager.Instance.coolDownReduction + Time.deltaTime;
            TEMP_CoolDownManager.Instance.coolDownReduction = TEMP_CoolDownManager.Instance.baseCoolDown
                * (TEMP_CoolDownManager.Instance.coolDownReduction / 2);

            Debug.Log(TEMP_CoolDownManager.Instance.coolDownReduction);
        }
        else
        {
            Debug.Log("nu uh");
        }
    }
}
