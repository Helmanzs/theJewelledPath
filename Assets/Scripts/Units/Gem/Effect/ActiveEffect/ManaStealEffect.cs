using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ManaStealEffect : ActiveEffect
{
    public override void Use(Enemy target, float value)
    {
        Global.Instance.Mana += (int)((target.Reward / 100) * value);
    }
    public override void Use(List<Enemy> targets, float value)
    {
        foreach (Enemy enemy in targets)
        {
            Use(enemy, value);
        }
    }
}
