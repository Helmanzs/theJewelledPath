using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MethodLeastHp : Method
{
    public override Enemy Aim(IEnumerable<Enemy> possibleTargets)
    {
        Enemy leastHPTarget = possibleTargets.FirstOrDefault();
        foreach (Enemy target in possibleTargets)
        {
            if (target.HP < leastHPTarget.HP)
                leastHPTarget = target;
        }
        return leastHPTarget;
    }

    public override TargetMethod ChangeMethod()
    {
        return TargetMethod.LeastHP;
    }
}
