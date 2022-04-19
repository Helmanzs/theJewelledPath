using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class FireEffect : ActiveEffect
{
    public override void Use(Enemy target, float value)
    {
        if (target == null) return;
        FireDamageOverTime fireDoT = target.gameObject.AddComponent<FireDamageOverTime>();
        fireDoT.Damage = 10 * value;
        fireDoT.ApplyEveryNSeconds = 1;
    }
    public override void Use(List<Enemy> targets, float value)
    {
        foreach (Enemy enemy in targets)
        {
            Use(enemy, value);
        }
    }
}
