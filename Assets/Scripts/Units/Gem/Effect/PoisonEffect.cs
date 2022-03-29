using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonEffect : ActiveEffect
{
    public override void Use(Enemy target, float value)
    {
        PoisonDamageOverTime poisonDoT = target.gameObject.AddComponent<PoisonDamageOverTime>();
        poisonDoT.Multiplier = value;
        poisonDoT.ApplyEveryNSeconds = 1;
    }
}
