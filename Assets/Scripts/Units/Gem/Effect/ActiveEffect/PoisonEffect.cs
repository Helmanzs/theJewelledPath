using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PoisonEffect : ActiveEffect
{
    public override void Use(Enemy target, float value)
    {
        PoisonDamageOverTime poisonDoT = target.gameObject.AddComponent<PoisonDamageOverTime>();
        poisonDoT.Multiplier = value;
        poisonDoT.ApplyEveryNSeconds = 1;
    }
    public override void Use(List<Enemy> targets, float value)
    {
        foreach (Enemy enemy in targets)
        {
            Use(enemy, value);
        }
    }
}
