/** Author's Name:          Sukhmannat Singh
 *  Last Modified By:       Sukhmannat Singh
 *  Date Last Modified:     November 3, 2023
 *  Program Description:    Classes for SaveData and PersistentUpgrades.
 *  Revision History:       November 3, 2023 (Sukhmannat Singh): Initial SaveData and PersistentUpgrades script.
 */

using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveData
{
    private static SaveData _currentData;

    public static SaveData currentData
    {
        get
        {
            if (_currentData == null)
            {
                _currentData = new SaveData();
            }
            return _currentData;
        }
        set
        {
            if (value != null)
            {
                _currentData = value;
            }
        }
    }

    public PersistentUpgrades persistentUpgrades;
}

[System.Serializable]
public class PersistentUpgrades
{
    public List<Stats> playerStats;
    public int gold;
}
