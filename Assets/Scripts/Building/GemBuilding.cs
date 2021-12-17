using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class GemBuilding : Building
{
    protected List<GameObject> gems = new List<GameObject>();
    protected List<Transform> targets = new List<Transform>();
    protected Transform _primaryTarget = null;

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
        protected set { attackSpeed = value; }
    }

    private void Start()
    {
        UpdateCollider(range);    
    }

    private void Update()
    {
        FindTarget();
    }

    protected abstract void InsertGem(GameObject gem);
    protected abstract void RemoveGem(GameObject gem);
    protected abstract void DealDamage(GameObject enemy);
    protected abstract void UpdateCollider(float range);

    protected void FindTarget()
    {
        if(_primaryTarget == null)
        {
            _primaryTarget = Target;
        }
    }

    public List<GameObject> GetPlacedGems
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {

            targets.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (ReferenceEquals(_primaryTarget, other.transform))
        {
            _primaryTarget = null;
        }

        targets.Remove(other.transform);
    }

}
