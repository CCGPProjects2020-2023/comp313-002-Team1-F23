using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float value = 5f;
}
