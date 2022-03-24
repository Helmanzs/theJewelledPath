using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class GemBuilding : Structure
{
    public GemHolder Gem;
    protected List<Enemy> possibleTargets = new List<Enemy>();

    private float damage = 0;
    private float range = 0;
    private float attackSpeed = 0;
    public float Damage
    {
        get { return damage; }
        protected set { damage = value; }
    }
    public float Range
    {
        get { return range; }
        protected set
        {
            if (range <= 0)
            {
                range = 0;
            }
            if (range > 9)
            {
                range = 9;
            }
            else
            {
                range = value / 2;
            }
            UpdateCollider(range);
        }
    }
    public float AttackSpeed
    {
        get { return attackSpeed; }
        protected set
        {
            attackSpeed = value;
        }
    }
    protected virtual void Awake()
    {
        UpdateCollider(range);
    }

    public abstract void InsertGem(Gem gem);
    public void EnableGem()
    {
        Gem.gameObject.SetActive(true);
    }
    protected abstract void DealDamage();
    protected abstract void UpdateCollider(float range);
    protected abstract void RemoveGem(GemHolder gem);
    public void AddTarget(Enemy target)
    {
        possibleTargets.Add(target);
    }
    public void RemoveTarget(Enemy target)
    {
        possibleTargets.Remove(target);
    }
}

/*protected List<Gem> gems = new List<Gem>();
protected Enemy _primaryTarget = null;
protected float nextTimeCall = 0;




protected abstract void UseGemEffect(Enemy target, Gem gem);

public List<Gem> GetPlacedGems
{
    get { return gems; }
}
protected virtual Enemy Target
{
    get
    {
        if (_primaryTarget == null)
        {
            targets.RemoveAll(eachTarget => { return eachTarget == null; });
            if (targets.Count > 0)
            {
                //_primaryTarget = targets.Find(target => { return true; });
            }
        }
        return _primaryTarget;
    }
}

protected virtual void FindTarget()
{
    if (_primaryTarget == null)
    {
        _primaryTarget = Target;
    }
}



public void RemoveTarget(Enemy other)
{
    if (ReferenceEquals(_primaryTarget, other))
    {
        _primaryTarget = null;
    }
    targets.Remove(other);
}
*/
