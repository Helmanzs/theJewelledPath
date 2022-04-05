using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class GemBuilding : Structure
{
    public GemHolder Gem;
    protected SphereCollider sphereCollider;
    protected override void Awake()
    {
        sphereCollider = GetComponentInChildren<SphereCollider>();
        base.Awake();
    }
    public virtual void EnableGem()
    {
        Gem.gameObject.SetActive(true);
    }
    public abstract void InsertGem(Gem gem);
    protected abstract void RemoveGem(GemHolder gem);
    public virtual void AddTarget<T>(T unit)
    {
        if (this is ISingleTargetStructure<T>)
        {
            this.GetComponent<ISingleTargetStructure<T>>().AddTarget(unit);
        }
        if (this is IAreaOfEffectStructure<T>)
        {
            this.GetComponent<IAreaOfEffectStructure<T>>().AddTarget(unit);
        }
    }
    public virtual void RemoveTarget<T>(T unit)
    {
        if (this is ISingleTargetStructure<T>)
        {
            this.GetComponent<ISingleTargetStructure<T>>().RemoveTarget(unit);
        }
        if (this is IAreaOfEffectStructure<T>)
        {
            this.GetComponent<IAreaOfEffectStructure<T>>().RemoveTarget(unit);
        }
    }

}