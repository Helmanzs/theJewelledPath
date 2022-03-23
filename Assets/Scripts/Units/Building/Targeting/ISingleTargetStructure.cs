using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISingleTargetStructure<T>
{
    public T Target { get; set; }
    public abstract ITargetable<T> FindTarget(TargetMethod method);
    public abstract void AddTarget(ITargetable<T> target);
    public abstract void RemoveTarget(ITargetable<T> target);

}

