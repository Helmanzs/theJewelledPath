using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LightningEffect : ActiveEffect
{
    public override void Use(Enemy target, float value)
    {
        int chainDepth = (int)Math.Round(value, MidpointRounding.AwayFromZero);
        if (chainDepth == 0) chainDepth = 10;
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
    public override void Use(List<Enemy> targets, float value)
    {
        foreach (Enemy enemy in targets)
        {
            Use(enemy, value);
        }
    }

}
