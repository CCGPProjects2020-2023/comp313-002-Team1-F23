/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     November 3, 2023
 *  Program Description:    A class representing a laser gun.
 *  Revision History:       November 3, 2023 (Marcus Ngooi): Initial LaserGun script.
 *                          November 28, 2023 (Marcus Ngooi): Adjustments from weaponSO change.
 *                                                            Refactoring.
 */

using System.Collections;
using UnityEngine;

public class LaserGun : Weapon
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform gunTransform;
    [SerializeField] private bool isActive;

    private const string ProjectileSpawner = "ProjectileSpawner";

    private void Start()
    {
        isActive = false;
        gunTransform = GameObject.FindWithTag(ProjectileSpawner).GetComponent<Transform>();
        weaponType = weaponSO.WeaponType;
        skillName = weaponType.ToString();
        maxLevel = weaponSO.MaxLevel;
        baseDamage = weaponSO.BaseDamage;
        baseCooldown = weaponSO.BaseCooldown;
        baseProjectileSpeed = weaponSO.BaseProjectileSpeed;
    }
    public override void Behaviour()
    {
        gunTransform = PlayerController.Instance.gunTransform;
        isActive = true;
        StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {
        while (isActive)
        {
            SoundManager.Instance.PlaySfx(SfxEvent.ShootLaserGun);
            GameObject laser = Instantiate(laserPrefab, gunTransform.position, gunTransform.rotation);
            Laser laserScript = laser.GetComponent<Laser>();
            laserScript.SetWeapon(this);
            yield return new WaitForSeconds(this.baseCooldown);
        }
    }
}
