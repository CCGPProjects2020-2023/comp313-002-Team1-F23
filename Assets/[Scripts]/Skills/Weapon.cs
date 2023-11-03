/*  Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     October 25, 2023
 *  Program Description:    Base class for a Weapon.
 *  Revision History:       October 25, 2023 (Marcus Ngooi): Initial Weapon script.
 *                          November 3, 2023 (Marcus Ngooi): 
 */

using UnityEngine;

public class Weapon : Skill
{
    private float speed;
    private float size;
    private float baseDamage;
    private int baseProjectiles;
    private float cooldown;
    private bool empowered;

    public WeaponType Type { get; private set; }

    public Weapon(WeaponType weaponType, int maxLevel) : base(weaponType.ToString(), maxLevel)
    {
        this.Type = weaponType;
    }

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
    public float CalculateSpeed()
    {
        return speed;
    }
    public float CalculateSize()
    {
        return size;
    }
    public float CalculateDamage()
    {
        float damage = 100 + baseDamage;
        return damage;
    }
    public int CalculateProjectiles()
    {
        int projectiles = 1 + baseProjectiles;
        return projectiles;
    }
    public float CalculateCooldown()
    {
        return cooldown;
    }
    public void Fire()
    {

    }
}
