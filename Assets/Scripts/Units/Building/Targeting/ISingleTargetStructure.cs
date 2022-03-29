using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISingleTargetStructure<T>
{
    public T Target { get; set; }
    public abstract T FindTarget(Method method);
    public abstract void RemoveTarget(T target);
    public void AddTarget(T target);

}

