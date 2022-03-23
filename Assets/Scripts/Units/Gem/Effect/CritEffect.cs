using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritEffect : ActiveEffect
{
    public override void Use(Enemy target, float value)
    {

        if (target.TryGetComponent<Vulnerable>(out Vulnerable vulnComponent))
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
}
