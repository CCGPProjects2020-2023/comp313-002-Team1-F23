/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     December 6, 2023
 *  Program Description:    Base class for a Weapon.
 *  Revision History:       October 25, 2023 (Marcus Ngooi): Initial Weapon script.
 *                          November 17, 2023 (Han Bi): Added empowered variable and function
 *                          November 28, 2023 (Marcus Ngooi): Added modifier amounts to account for upgrades and buffs.
 *                          November 29, 2023 (Marcus Ngooi): Removed unused functions.
 *                          November 29, 2023 (Marcus Ngooi): Added Calculate functions for stats.
 *                                                            Added debugging to virtual Behaviour() function.
 *                          November 28, 2023 (Mithul): Added weapon evolution scripts
 *                          November 28, 2023 (Ikamjot Hundal): Made the basecooldown public for access
 *                          December 6, 2023 (Marcus Ngooi): Bug fixes.
 */

using System.Collections.Generic;
using UnityEngine;

public class Weapon : Skill
{
    [SerializeField] protected WeaponType weaponType;

    [SerializeField] protected float calculatedDamage = 0f;
    [SerializeField] protected float calculatedCooldown = 0f;
    [SerializeField] protected float calculatedProjectileSpeed = 0f;

    [SerializeField] protected List<WeaponSO> weaponLevelSOs = new();

    [SerializeField] protected float empoweredModifier = 0.25f;

    public bool empowered = false;
    public WeaponType WeaponType { get => weaponType; }
    public float CalculatedDamage { get => calculatedDamage; }
    public float CalculatedCooldown { get => calculatedCooldown; }
    public float CalculatedProjectileSpeed { get => calculatedProjectileSpeed; }
    public bool isEvolved = false;
    [SerializeField] private float evolvedDamageMultiplier = 1.5f;

    public virtual void Behaviour()
    {
        Debug.Log("Behaviour() from base Weapon class called.");
    }
    public void CalculateDamage()
    {
        // TODO: Add amounts persistent upgrades.
        if (empowered)
        {
            calculatedDamage = (weaponLevelSOs[currentLevel].BaseDamage + PlayerController.Instance.damage) * (1 + empoweredModifier);
        }
        Buff redTarget = SkillManager.Instance.GetBuff(BuffType.RedTarget);
        if (redTarget != null)
        {
            calculatedDamage += redTarget.GetBuffAmount();
        }
    }
    public void CalculateCooldown()
    {
        // TODO: Add amounts from persistent upgrades.
        calculatedCooldown = weaponLevelSOs[currentLevel].BaseCooldown;
        Buff stopWatch = SkillManager.Instance.GetBuff(BuffType.Stopwatch);
        if (stopWatch != null)
        {
            calculatedCooldown -= stopWatch.GetBuffAmount() / 100;
        }
    }
    public void CalculateProjectileSpeed()
    {
        // TODO: Add amounts from buffs, persistent upgrades.
        calculatedProjectileSpeed = weaponLevelSOs[currentLevel].BaseProjectileSpeed;
    }
    public void CalculateStats()
    {
        CalculateDamage();
        CalculateCooldown();
        CalculateProjectileSpeed();
    }
    public void EmpowerWeapon()
    {
        if (!empowered)
        {
            empowered = true;
        }

    }
    public void EvolveWeapon()
    {       
            isEvolved = !isEvolved; // Toggle the evolved state.
        
    }
}
