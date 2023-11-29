/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     November 3, 2023
 *  Program Description:    Holds Weapon data.
 *  Revision History:       November 3, 2023 (Marcus Ngooi): Initial WeaponSO script.
 *                          November 28, 2023 (Marcus Ngooi): Made values private.
 */

using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public class WeaponSO : ScriptableObject
{

    [SerializeField] private int maxLevel;
    [SerializeField] private float baseDamage;
    [SerializeField] private float baseCooldown;
    [SerializeField] private float baseProjectileSpeed;
    [SerializeField] private WeaponType weaponType;

    public int MaxLevel { get => maxLevel; private set => maxLevel = value; }
    public float BaseDamage { get => baseDamage; private set => baseDamage = value; }
    public float BaseCooldown { get => baseCooldown; private set => baseCooldown = value; }
    public float BaseProjectileSpeed { get => baseProjectileSpeed; private set => baseProjectileSpeed = value; }
    public WeaponType WeaponType { get => weaponType; private set => weaponType = value; }
}
