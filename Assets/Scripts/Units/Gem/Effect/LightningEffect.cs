using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningEffect : ActiveEffect
{
    public override Effect Clone()
    {
        LightningEffect temp = new LightningEffect();
        return temp;
    }

    public override void Use(Enemy target, float value)
    {
        int chainDepth = (int)Math.Round(value, MidpointRounding.AwayFromZero);
        ApplyLightning(target, chainDepth, value);
    }

    private void ApplyLightning(Enemy target, int chainDepth, float damageMultiplier)
    {
        if (chainDepth == 0 || target == null) return;

        Enemy nextTarget = GetClosestEnemy(target);
        nextTarget.ApplyDamage(10 * damageMultiplier);
        ApplyLightning(nextTarget, chainDepth - 1, damageMultiplier);
    }

    Enemy GetClosestEnemy(Enemy target)
    {
        Enemy bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = target.transform.position;
        foreach (Enemy potentialTarget in Global.Instance.enemies)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr && target != potentialTarget)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }

}
