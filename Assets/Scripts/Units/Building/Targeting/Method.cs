using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Method : MonoBehaviour
{
    public TargetMethod TargetMethod;
    protected Structure structure;

    public virtual void InitState(Structure structure)
    {
        this.structure = structure;
    }

    public abstract TargetMethod ChangeState();

    public abstract void Aim();
}
