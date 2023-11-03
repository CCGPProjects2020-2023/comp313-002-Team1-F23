using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : Skill
{

    public BuffType Type { get; private set; }

    public Buff(BuffType type, int maxLevel) : base(type.ToString(), maxLevel)
    {
        this.Type = type;
    }

    public virtual void ApplyBuff() { }


}
