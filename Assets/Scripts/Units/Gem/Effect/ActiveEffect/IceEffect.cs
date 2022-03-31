using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class IceEffect : ActiveEffect
{
    public override void Use(Enemy target, float value)
    {
        target.Speed = target.DefaultSpeed * value;
    }
    public override void Use(List<Enemy> targets, float value)
    {
        foreach (Enemy enemy in targets)
        {
            Use(enemy, value);
        }
    }
}
