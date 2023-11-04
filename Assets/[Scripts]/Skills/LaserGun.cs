using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : Weapon
{
    private WeaponType weaponType;
    [SerializeField] private const int maxLevel = 4;
    public LaserGun(WeaponType weaponType) : base (WeaponType.LaserGun, maxLevel)
    {
        this.weaponType = weaponType;
    }
    public override void Behaviour()
    {
        base.Behaviour();
    }
}
