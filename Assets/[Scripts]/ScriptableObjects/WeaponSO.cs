/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     November 3, 2023
 *  Program Description:    Holds Weapon data.
 *  Revision History:       November 3, 2023 (Marcus Ngooi): Initial WeaponSO script.
 */

using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public class WeaponSO : ScriptableObject
{
    public int maxLevel;
    public float baseDamage;
    public float baseCooldown;
    public float baseProjectileSpeed;
    public WeaponType weaponType;
}
