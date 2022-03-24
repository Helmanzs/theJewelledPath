using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISingleTargetStructure<T>
{
    public T Target { get; set; }
    public abstract T FindTarget(Method method);

}

