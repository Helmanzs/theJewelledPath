using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaStealEffect : ActiveEffect
{
    public override void Use(Enemy target, float value)
    {
        Global.Instance.Mana += (int)((target.Reward / 100) * value);
    }
}
