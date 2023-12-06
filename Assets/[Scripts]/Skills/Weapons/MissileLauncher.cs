/** Author's Name:          Mithul Koshy
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     November 28, 2023
 *  Program Description:    A script to handle the MissileLauncher weapon.
 *  Revision History:       November 28, 2023 (Mithul Koshy):
 *                          November 29, 2023 (Marcus Ngooi): Updated with new stats system.
 *                          December 05, 2023 (Mithul Koshy): Added new missile launcher evolutions
 */

using System.Collections;
using System.Reflection;
using UnityEngine;


public class MissileLauncher : Weapon
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launcherTransform;
    [SerializeField] private GameObject evolvedMissilePrefab;
    [SerializeField] private bool isActive;

    // Add variables for evolved missile parameters.
    [SerializeField] private float evolvedMissileSizeIncrease = 1.5f;
    [SerializeField] private float evolvedMissileExplosionRadius = 5f;
    [SerializeField] private int evolvedMissileDamage = 20;

    private const string ProjectileSpawner = "ProjectileSpawner";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            EvolveWeapon();
        }
    }

    private void Start()
    {
        isActive = false;
        launcherTransform = GameObject.FindWithTag(ProjectileSpawner).GetComponent<Transform>();
        weaponType = weaponLevelSOs[0].WeaponType;
        skillName = weaponType.ToString();
        maxLevel = weaponLevelSOs[0].MaxLevel;
        CalculateStats();
    }

    public override void Behaviour()
    {
        launcherTransform = PlayerController.Instance.gunTransform;
        isActive = true;
        StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {
        while (isActive)
        {
            SoundManager.Instance.PlaySfx(SfxEvent.ShootMissile);

            if (isEvolved)
            {
                // Shoot an evolved missile.
                GameObject missile = Instantiate(evolvedMissilePrefab, launcherTransform.position, launcherTransform.rotation);
                Missile missileScript = missile.GetComponent<Missile>();

                // Modify evolved missile size.
                missileScript.SetWeapon(this);
                missileScript.transform.localScale *= evolvedMissileSizeIncrease;
            }
            else
            {
                // Shoot a regular missile.
                GameObject missile = Instantiate(missilePrefab, launcherTransform.position, launcherTransform.rotation);
                Missile missileScript = missile.GetComponent<Missile>();
                missileScript.SetWeapon(this);
            }

            yield return new WaitForSeconds(calculatedCooldown);
        }
    }
}
