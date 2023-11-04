using System.Collections;
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
