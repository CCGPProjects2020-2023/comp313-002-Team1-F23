/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Mithul Koshy
 *  Date Last Modified:     November 28, 2023
 *  Program Description:    Base class for a Weapon.
 *  Revision History:       October 25, 2023 (Marcus Ngooi): Initial Weapon script.
 *                          November 3, 2023 (Marcus Ngooi): 
 *                          November 17, 2023 (Han Bi): Added empowered variable and function
 *                          November 28, 2023 (Mithul): Added weapon evolution scripts
 *                          November 28, 2023 (Ikamjot Hundal): Made the basecooldown public for access
 */

using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Weapon : Skill
{
    [SerializeField] protected WeaponType weaponType;
    [SerializeField] protected float baseDamage;
    public float baseCooldown;
    [SerializeField] protected float baseProjectileSpeed;
    [SerializeField] protected WeaponSO weaponSO;



    public bool empowered = false;
    public bool isEvolved = false;
    [SerializeField] private float evolvedDamageMultiplier = 1.5f;
    public float BaseCooldown { get => baseCooldown; private set => baseCooldown = value; }
    public float BaseProjectileSpeed { get => baseProjectileSpeed; private set => baseProjectileSpeed = value; }
    public WeaponType WeaponType { get => weaponType; private set => weaponType = value; }

    public WeaponSO WeaponSO { get { return weaponSO; } }

    public virtual void Behaviour()
    {
    }

    public Vector2 FindTarget()
    {
        return new Vector2(0, 0);
    }

    public void IncreaseProjectiles(int increase)
    {
    }

    public void EmpowerWeapon()
    {
        if (!empowered)
        {
            baseDamage *= 1.25f;
            empowered = true;
        }
    }

    public void EvolveWeapon()
    {
        if (!isEvolved)
        {
            baseDamage *= evolvedDamageMultiplier;
            isEvolved = true;
        }
    }


}
