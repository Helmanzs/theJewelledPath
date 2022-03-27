using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MethodFurthest : Method
{
    public override Enemy Aim(IEnumerable<Enemy> possibleTargets)
    {
        Enemy closestEnemy = possibleTargets.FirstOrDefault();
        float currentDistance = closestEnemy.GetDistanceToUnit(structure);

        foreach (Enemy target in possibleTargets)
        {
            float dist = target.GetDistanceToUnit(structure);
            if (currentDistance < dist)
                closestEnemy = target;
        }
        return closestEnemy;
    }

    public override TargetMethod ChangeMethod()
    {
        return TargetMethod.Furthest;
    }
    public override string GetName()
    {
        return "Target Furthest";
    }
}
