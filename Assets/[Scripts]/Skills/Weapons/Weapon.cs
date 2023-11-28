/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Mithul Koshy
 *  Date Last Modified:     November 28, 2023
 *  Program Description:    Base class for a Weapon.
 *  Revision History:       October 25, 2023 (Marcus Ngooi): Initial Weapon script.
 *                          November 3, 2023 (Marcus Ngooi): 
 *                          November 17, 2023 (Han Bi): Added empowered variable and function
 *                          November 28, 2023 (Mithul): Added weapon evolution scripts
 */

using UnityEngine;

public class Weapon : Skill
{
    [SerializeField] protected WeaponType weaponType;
    [SerializeField] protected float baseDamage;
    [SerializeField] protected float baseCooldown;
    [SerializeField] protected float baseProjectileSpeed;
    [SerializeField] protected WeaponSO weaponSO;



    public bool empowered = false;
    public bool isEvolved = false;
    [SerializeField] private float evolvedDamageMultiplier = 1.5f;

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
