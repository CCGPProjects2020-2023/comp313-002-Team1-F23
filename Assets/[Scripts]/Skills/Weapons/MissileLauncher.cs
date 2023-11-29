/** Author's Name:          Mithul Koshy
 *  Last Modified By:       Mithul Koshy
 *  Date Last Modified:     November 28, 2023
 *  Program Description:    A script to handle the MissileLauncher weapon.
 *  Revision History:       November 28, 2023 (Mithul Koshy): 
 */

using System.Collections;
using System.Reflection;
using UnityEngine;

public class MissileLauncher : Weapon
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launcherTransform;
    [SerializeField] private bool isActive;

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
        weaponType = weaponSO.WeaponType;
        skillName = weaponType.ToString();
        maxLevel = weaponSO.MaxLevel;
        baseDamage = weaponSO.BaseDamage;
        baseCooldown = weaponSO.BaseCooldown;
        baseProjectileSpeed = weaponSO.BaseProjectileSpeed;
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
            GameObject missile = Instantiate(missilePrefab, launcherTransform.position, launcherTransform.rotation);
            if (isEvolved)
            {
                missile.GetComponent<Missile>().SetEvolvedProperties();
            }
            yield return new WaitForSeconds(weaponSO.BaseCooldown);
        }
    }
}
