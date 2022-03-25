using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MethodBoss : Method
{
    public override Enemy Aim(IEnumerable<Enemy> possibleTargets)
    {
        foreach (Enemy target in possibleTargets)
        {
            if (target.TryGetComponent<Boss>(out Boss bossEnemy))
            {
                return bossEnemy as Enemy;
            }
        }
        return possibleTargets.FirstOrDefault();
    }

    public override TargetMethod ChangeMethod()
    {
        return TargetMethod.Boss;
    }
}
