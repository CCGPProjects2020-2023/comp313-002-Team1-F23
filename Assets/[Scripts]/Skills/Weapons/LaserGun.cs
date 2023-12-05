/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     November 3, 2023
 *  Program Description:    A class representing a laser gun.
 *  Revision History:       November 3, 2023 (Marcus Ngooi): Initial LaserGun script.
 *                          November 28, 2023 (Marcus Ngooi): Adjustments from weaponSO change.
 *                                                            Refactoring.
 *                          November 29, 2023 (Marcus Ngooi): 
 *                          November 28, 2023 (Ikamjot Hundal): Instantiate a copy of the WeaponSO 
 *                              and use that copy to make changes to base cooldown
 */

using System.Collections;
using UnityEngine;

public class LaserGun : Weapon
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform gunTransform;
    [SerializeField] private bool isActive;

    private const string ProjectileSpawner = "ProjectileSpawner";

    WeaponSO weaponSOCopy;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            EvolveWeapon();
        }

       // weaponSOCopy.baseCooldown = baseCooldown; 
    }

    private void Start()
    {
        isActive = false;
        gunTransform = GameObject.FindWithTag(ProjectileSpawner).GetComponent<Transform>();
        weaponType = weaponLevelSOs[0].WeaponType;
        skillName = weaponType.ToString();
        maxLevel = weaponLevelSOs[0].MaxLevel;
        CalculateStats();
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
            if (isEvolved)
            {
                // Modify the laser if the weapon is evolved
                laser.GetComponent<Laser>().SetEvolvedProperties();
            }
            Laser laserScript = laser.GetComponent<Laser>();
            laserScript.SetWeapon(this);
            yield return new WaitForSeconds(calculatedCooldown);
        }
    }
}
