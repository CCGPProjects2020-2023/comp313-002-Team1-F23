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

    }

    public override void ApplyBuff()
    {
        // TEMP_CoolDownManager.Instance.coolDownReduction = currentLevel * decreaseCooldownRate / 100 * TEMP_CoolDownManager.Instance.baseCoolDown;
        //weaponSO.baseCooldown = currentLevel * decreaseCooldownRate / 100 * weaponSO.baseCooldown;

        // --------Specific to Laser Gun ---------- Cons: It directly modify the SO, not the game object. 

        /* TEMP_CoolDownManager.Instance.coolDownReduction = currentLevel * decreaseCooldownRate / 100 * laserGunObject.WeaponSO.baseCooldown;

         Debug.Log(TEMP_CoolDownManager.Instance.coolDownReduction);


         laserGunObject.WeaponSO.baseCooldown = laserGunObject.WeaponSO.baseCooldown - TEMP_CoolDownManager.Instance.coolDownReduction;

         Debug.Log(laserGunObject.WeaponSO.baseCooldown);

         */
        //---------------------------------------------------------------


        if (currentLevel < maxLevel)
        {

            //TEMP_CoolDownManager.Instance.baseCoolDown = laserGunObject.baseCooldown;

            LaserGunReduction();


            //weaponSO.baseCooldown = weapon.baseCooldown;
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


    public void MissileLauncherReduction()
    {
        float missileLauncherReduction = currentLevel * decreaseCooldownRate / 100 * missileLauncherObject.baseCooldown;

        Debug.Log(missileLauncherReduction);

        missileLauncherObject.baseCooldown = missileLauncherObject.baseCooldown - missileLauncherReduction;

        Debug.Log(missileLauncherObject.baseCooldown);
    }

    /*public void AttackDroneReduction()
    {
        float attackDroneReduction = currentLevel * decreaseCooldownRate / 100 * attackDronesObject.baseCooldown;

        Debug.Log(attackDroneReduction);

        missileLauncherObject.baseCooldown = missileLauncherObject.baseCooldown - attackDroneReduction;

        Debug.Log(missileLauncherObject.baseCooldown);
    } */
}
