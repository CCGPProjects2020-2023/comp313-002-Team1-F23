/** Author's Name:          Sukhmannat Singh
 *  Last Modified By:       Sukhmannat Singh
 *  Date Last Modified:     October 15, 2023
 *  Program Description:    A standalone class for Stats.
 *  Revision History:       October 15, 2023 (Sukhmannat Singh): Initial Stats class script.
 */

[System.Serializable]
public class Stats
{
    //BuffsSystem buffsSystem = new BuffsSystem();

    public enum Stat
    {
        Damage,
        Health,
        Armor,
        MoveSpeed,
        GoldGain,
        PickupRange,
        Luck
    }

    public Stat stat;
    public float value;
    public float maxValue;
}
