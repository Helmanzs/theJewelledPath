using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class IceEffect : ActiveEffect
{
    public override void Use(Enemy target, float value)
    {
        if (target == null) return;

        if (target.TryGetComponent(out Chill chillComponent))
        {
            chillComponent.RefreshDuration(5);
            if (chillComponent.Multiplier < value)
                chillComponent.Multiplier = value;
        }
        else
        {
            chillComponent = target.gameObject.AddComponent<Chill>();
            chillComponent.Multiplier = value;
            chillComponent.RefreshDuration(5);
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
