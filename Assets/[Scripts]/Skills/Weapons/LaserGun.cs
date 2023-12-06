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
 *                          December 05, 2023 (Mithul Koshy): Modified LaserGun to include evolved laser.
 *                              
 */

using System.Collections;
using UnityEngine;

public class LaserGun : Weapon
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform gunTransform;
    [SerializeField] private GameObject evolvedLaserPrefab; // Add a reference to the evolved laser prefab.
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

            if (isEvolved)
            {
                // Shoot three evolved lasers with some spacing between them.
                for (int i = 0; i < 3; i++)
                {
                    float angle = -15f + i * 15f; // Adjust the angle spacing as needed.
                    Quaternion rotation = gunTransform.rotation * Quaternion.Euler(0f, 0f, angle);
                    GameObject laser = Instantiate(evolvedLaserPrefab, gunTransform.position, rotation);
                    Laser laserScript = laser.GetComponent<Laser>();
                    laserScript.SetWeapon(this);
                }
            }
            else
            {
                // Shoot a single regular laser.
                GameObject laser = Instantiate(laserPrefab, gunTransform.position, gunTransform.rotation);
                Laser laserScript = laser.GetComponent<Laser>();
                laserScript.SetWeapon(this);
            }

            yield return new WaitForSeconds(calculatedCooldown);
        }
    }


}
