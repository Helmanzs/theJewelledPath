using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MethodMostHP : Method
{
    public override Enemy Aim(IEnumerable<Enemy> possibleTargets)
    {
        Enemy mostHPTarget = possibleTargets.FirstOrDefault();
        foreach (Enemy target in possibleTargets)
        {
            if (target.HP > mostHPTarget.HP)
                mostHPTarget = target;
        }
        return mostHPTarget;
    }

    public override TargetMethod ChangeMethod()
    {
        return TargetMethod.LeastHP;
    }
    public override string GetName()
    {
        return "Target Highest HP";
    }
}
