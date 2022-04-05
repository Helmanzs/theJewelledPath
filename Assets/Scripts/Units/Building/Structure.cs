using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

abstract public class Structure : Unit, IClickable
{

    protected static StructureEvent OnStructurePlaced;

    public float cost;
    private TargetStateManager methodManager;
    private float range = 0;
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

    protected virtual void Start()
    {
        methodManager = GetComponent<TargetStateManager>();
        OnStructurePlaced?.Invoke(this);
    }
    protected virtual void Awake()
    {
        if (OnStructurePlaced == null)
            OnStructurePlaced = new StructureEvent();
        UpdateCollider(range);
    }
    protected virtual void FixedUpdate()
    {
        // AmplifierModifierRequest?.Invoke(this);
        Act();
    }
    protected abstract void Act();
    public void InvokeBuiltStructure()
    {
        OnStructurePlaced?.Invoke(this);
    }
    public abstract void Click(Vector3 mousePos);
    protected abstract void UpdateCollider(float range);
    public void SetMethod(TargetMethod method)
    {
        methodManager.ChangeMethod(method);
    }

}