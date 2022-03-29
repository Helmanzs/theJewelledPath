using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class GemBuilding : Structure
{

    public GemHolder Gem;
    protected virtual List<Enemy> PossibleTargets { get; set; }

    private float damage = 0;
    private float attackSpeed = 0;
    public float Damage
    {
        get { return damage; }
        protected set { damage = value; }
    }

    public float AttackSpeed
    {
        get { return attackSpeed; }
        protected set
        {
            attackSpeed = value;
        }
    }


    public abstract void InsertGem(Gem gem);
    public void EnableGem()
    {
        Gem.gameObject.SetActive(true);
    }
    protected abstract void DealDamage();
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