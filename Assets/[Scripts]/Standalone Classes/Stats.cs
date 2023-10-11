using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
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
}
