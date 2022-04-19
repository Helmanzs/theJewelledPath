using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CritEffect : ActiveEffect
{
    public override void Use(Enemy target, float value)
    {
        if (target == null) return;

        if (target.TryGetComponent(out Vulnerable vulnComponent))
        {
            vulnComponent.RefreshDuration(5);
            if (vulnComponent.multiplier < value)
                vulnComponent.multiplier = value;
        }
        else
        {
            vulnComponent = target.gameObject.AddComponent<Vulnerable>();
            vulnComponent.multiplier = value;
            vulnComponent.Seconds = 5;
        }

    }

    public override void Use(List<Enemy> targets, float value)
    {
        foreach (Enemy enemy in targets)
        {
            Use(enemy, value);
        }
    }
}
