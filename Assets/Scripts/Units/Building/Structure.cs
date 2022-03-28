using System.Collections;
using System.Collections.Generic;
using UnityEngine;
abstract public class Structure : Unit, IClickable
{
    public float cost;
    private float range = 0;
    private TargetStateManager methodManager;

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

    private void Start()
    {
        methodManager = GetComponent<TargetStateManager>();
    }
    protected virtual void Awake()
    {
        UpdateCollider(range);
    }
    protected abstract void UpdateCollider(float range);
    public abstract void Click(Vector3 mousePos);
    public void SetMethod(TargetMethod method)
    {
        methodManager.ChangeMethod(method);
    }

}