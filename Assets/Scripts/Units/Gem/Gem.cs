using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Gem : Unit
{
    public float damage = 0;
    public float range = 0;
    public float attackSpeed = 0;
    public float cost = 0;
    private Effect effect = null;
    private Color color;

    private void Awake()
    {
        effect = GetComponent<Effect>();
    }
    public Effect Effect
    {
        get { return effect; }
        protected set { effect = value; }
    }
    public Color Color
    {
        get { return color; }
        protected set { color = value; }
    }
}
