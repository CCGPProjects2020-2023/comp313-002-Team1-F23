/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     October 25, 2023
 *  Program Description:    Base class for a Weapon.
 *  Revision History:       October 25, 2023 (Marcus Ngooi): Initial Weapon script.
 *                          November 3, 2023 (Marcus Ngooi): 
 *                          November 17, 2023 (Han Bi): Added empowered variable and function
 */

using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Weapon : Skill
{
    [SerializeField] protected WeaponType weaponType;
    [SerializeField] protected float baseDamage;
    [SerializeField] protected float baseCooldown;
    [SerializeField] protected float baseProjectileSpeed;

    [SerializeField] protected WeaponSO weaponSO;

    public bool empowered = false;
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
        }
    }

}
