using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MethodRandom : Method
{
    public override Enemy Aim(IEnumerable<Enemy> possibleTargets)
    {
        return possibleTargets.RandomElement();
    }

    public override TargetMethod ChangeMethod()
    {
        return TargetMethod.Random;
    }
    public override string GetName()
    {
        return "Target Random";
    }
}
