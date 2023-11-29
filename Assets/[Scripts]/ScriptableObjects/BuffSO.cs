/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     November 29, 2023
 *  Program Description:    Holds Buff data.
 *  Revision History:       November 29, 2023 (Marcus Ngooi): Initial BuffSO script.
 */

using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Buff", menuName = "Scriptable Objects/Buff")]
public class BuffSO : ScriptableObject
{
    [SerializeField] private int maxLevel;
    [SerializeField] private float baseBuffAmount;
    [SerializeField] private BuffType buffType;

    public int MaxLevel { get => maxLevel; private set => maxLevel = value; }
    public BuffType BuffType { get => buffType; private set => buffType = value; }
    public float BaseBuffAmount { get => baseBuffAmount; private set => baseBuffAmount = value; }
}
