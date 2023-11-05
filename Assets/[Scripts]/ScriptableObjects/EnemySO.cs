/** Author's Name:          Han Bi
 *  Last Modified By:       Han Bi
 *  Date Last Modified:     October 25, 2023
 *  Program Description:    Holds Enemy data.
 *  Revision History:       October 25, 2023 (Han Bi): Initial EnemySO script.
 */

using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName ="Scriptable Objects/Enemy")]
public class EnemySO : ScriptableObject
{
    public float baseExp;

    public float baseHealth;

    public float baseSpeed;

    public float baseDamage;

}
