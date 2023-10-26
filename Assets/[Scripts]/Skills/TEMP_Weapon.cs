/*  Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     October 25, 2023
 *  Program Description:    Base class for a Weapon.
 *  Revision History:       October 25, 2023: Initial Weapon script.
 */

using UnityEngine;

public class TEMP_Weapon
{
    public enum WeaponType
    {
        LaserGun,
        RotatingLaserTower,
        MissileLauncher,
        MissileBarrageLauncher,
        AttackDrones,
        MobileAttackDrones
    }
    private WeaponType weaponType;
    private float speed;
    private float size;
    private float baseDamage;
    private int baseProjectiles;
    private float cooldown;
    private int currentLevel;
    private int maxLevel;
    private string description;
    private bool empowered;

    public TEMP_Weapon()
    {

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
    public WeaponType GetType()
    {
        return weaponType;
    }
    public bool IsMaxLevel()
    {
        return currentLevel >= maxLevel;
    }
}
