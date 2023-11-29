/**Author's Name:          Ikamjot Hundal
 * Last Modified By:       Ikamjot Hundal
 * Date Last Modified:     November 1st, 2023 
 * Description:            Child Class to TEMP_Buff.cs for managing Cooldown Rate
 * ------------------------------------------------------------------------
 * Revision History:       October 26, 2023 (Ikamjot Hundal): Initial StopWatch script.
 *                         October 28, 2023 (Ikamjot Hundal): Updated the script to be the child of TEMP_Buff
 *                         October 30 2023 (Ikamjot Hundal): Changed to override method
 *                         November 1, 2023 (Ikamjot Hundal): Setting the BuffType
 *                         November 3, 2023 (Ikamjot Hundal): Revamping the calucations 
 *                         November 28, 2023 (Ikamjot Hundal): Updated the ApplyBuff to be applied certain times and updating laser gun for now. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : Buff
{
    [SerializeField] private float decreaseCooldownRate = 10f;

    [SerializeField] TEMP_CoolDownManager coolDownManager;


    [Header("Weapons")]
    [SerializeField] LaserGun laserGunObject;

    [SerializeField] MissileLauncher missileLauncherObject;

    [SerializeField] AttackDrones attackDronesObject;

    private void Start()
    {
        buffType = BuffType.Stopwatch;
        laserGunObject = FindAnyObjectByType<LaserGun>();
        missileLauncherObject = FindAnyObjectByType<MissileLauncher>();
        attackDronesObject = FindAnyObjectByType<AttackDrones>();

    }

    public override void ApplyBuff()
    {
        if (currentLevel < maxLevel)
        {
            LaserGunReduction();
            AttackDroneReduction();

            currentLevel++;
        }
        else
        {
            Debug.Log("No more level");
        }
    }


    public void LaserGunReduction()
    {
        float laserGunReduction = currentLevel * decreaseCooldownRate / 100 * laserGunObject.baseCooldown;

        Debug.Log(laserGunReduction);

        laserGunObject.baseCooldown = laserGunObject.baseCooldown - laserGunReduction;

        Debug.Log(laserGunObject.baseCooldown);
    }


   /* public void MissileLauncherReduction()
    {
        float missileLauncherReduction = currentLevel * decreaseCooldownRate / 100 * missileLauncherObject.baseCooldown;

        Debug.Log(missileLauncherReduction);

        missileLauncherObject.baseCooldown = missileLauncherObject.baseCooldown - missileLauncherReduction;

        Debug.Log(missileLauncherObject.baseCooldown);
    } */

    public void AttackDroneReduction()
    {
        float attackDroneReduction = currentLevel * decreaseCooldownRate / 100 * attackDronesObject.baseCooldown;

        Debug.Log(attackDroneReduction);

        attackDronesObject.baseCooldown = attackDronesObject.baseCooldown - attackDroneReduction;

        Debug.Log(attackDronesObject.baseCooldown);
    } 
}
