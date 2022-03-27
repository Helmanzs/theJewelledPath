using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Method : MonoBehaviour
{
    protected Structure structure;

    public virtual void InitState(Structure structure)
    {
        this.structure = structure;
    }

    public abstract TargetMethod ChangeMethod();

    public abstract Enemy Aim(IEnumerable<Enemy> possibleTargets);

    public abstract string GetName();
}
