using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAreaOfEffectStructure<T>
{
    public List<T> Targets { get; set; }
    public abstract List<T> FindTargets();
    public abstract void AddTarget(T target);
    public abstract void RemoveTarget(T target);
    public List<T> PossibleTargets { get; set; }

}
