using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAreaOfEffectStructure<T>
{
    public List<T> Targets { get; set; }
    public abstract void AddTarget(T target);
    public abstract void RemoveTarget(T target);

}
