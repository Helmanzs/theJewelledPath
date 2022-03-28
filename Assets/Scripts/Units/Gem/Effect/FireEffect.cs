using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : ActiveEffect
{
    public override Effect Clone()
    {
        FireEffect temp = new FireEffect();
        return temp;
    }

    public override void Use(Enemy target, float value)
    {
        FireDamageOverTime fireDoT = target.gameObject.AddComponent<FireDamageOverTime>();
        fireDoT.Damage = 10 * value;
        fireDoT.ApplyEveryNSeconds = 1;
    }
}
