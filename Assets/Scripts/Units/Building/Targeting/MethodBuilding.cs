using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MethodBuilding : Method
{
    public override Enemy Aim(IEnumerable<Enemy> possibleTargets)
    {
        return possibleTargets.FirstOrDefault();
    }

    public override TargetMethod ChangeMethod()
    {
        return TargetMethod.Building;
    }
    public override string GetName()
    {
        return "Target Building";
    }
}


