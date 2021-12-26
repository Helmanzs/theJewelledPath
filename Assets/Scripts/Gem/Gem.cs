using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Gem : Unit
{
    private float damage = 0;
    private float range = 0;
    private float attackSpeed = 0;
    private Effect effect = null;

    private void Start()
    {
        effect = GetComponent<Effect>();
    }

    public float Damage
    {
        get { return damage; }
        protected set { damage = value; }
    }

    public Effect Effect
    {
        get { return effect; }
    }
    public float Range
    {
        get { return range; }
        protected set { range = value; }
    }
    public float AttackSpeed
    {
        get { return attackSpeed; }
        protected set { attackSpeed = value; }
    }

    public override string ToString()
    {
        return $"Damage: {Damage}, Range: {Range}, Attackspeed: {AttackSpeed}";
    }
}
