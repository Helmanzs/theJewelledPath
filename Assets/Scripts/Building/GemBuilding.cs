using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class GemBuilding : Structure
{
    protected List<Gem> gems = new List<Gem>();
    protected List<Transform> targets = new List<Transform>();
    protected Gem showcasedGem = null;
    protected Transform _primaryTarget = null;
    protected float elapsedTime = 0;
    protected float nextTimeCall = 0;
    protected Dictionary<string, float> weighting = new Dictionary<string, float>();

    private float damage = 0;
    private float range = 0;
    private float attackSpeed = 0;

    public Gem ShowcasedGem
    {
        get { return showcasedGem; }
        set { showcasedGem = value; }
    }
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
            range = value;

            if (range < 0)
            {
                range = 0;
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
            if (1 - attackSpeed / 1000 <= 0)
            {
                attackSpeed = 0.1f;
            }
        }
    }
    private void Awake()
    {
        UpdateCollider(range);
    }

    private void FixedUpdate()
    {
        FindTarget();
        if (_primaryTarget != null)
        {
            DealDamage();
        }
    }


    public abstract void InsertGem(Gem gem);
    protected abstract void RemoveGem(GameObject gem);
    protected abstract void DealDamage();
    protected abstract void UpdateCollider(float range);
    protected abstract void UseGemEffect(GameObject target, Gem gem);

    protected void FindTarget()
    {
        if (_primaryTarget == null)
        {
            _primaryTarget = Target;
        }
    }

    protected void RecalculateWeigthing()
    {

    }

    public List<Gem> GetPlacedGems
    {
        get { return gems; }
    }
    private Transform Target
    {
        get
        {
            if (_primaryTarget == null)
            {
                targets.RemoveAll(eachTarget => { return eachTarget == null; });
                if (targets.Count > 0)
                {
                    _primaryTarget = targets.Find(target => { return true; });
                }
            }
            return _primaryTarget;
        }
    }

    public void AddTarget(Transform other)
    {
        print("kjek");
        targets.Add(other);
    }

    public void RemoveTarget(Transform other)
    {
        if (ReferenceEquals(_primaryTarget, other.transform))
        {
            _primaryTarget = null;
        }
        targets.Remove(other.transform);
    }

}
