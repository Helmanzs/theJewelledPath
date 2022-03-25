using System.Collections;
using System.Collections.Generic;
using UnityEngine;
abstract public class Structure : Unit
{
    public float cost;
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
    protected virtual void Awake()
    {
        UpdateCollider(range);
    }
    protected abstract void UpdateCollider(float range);

}