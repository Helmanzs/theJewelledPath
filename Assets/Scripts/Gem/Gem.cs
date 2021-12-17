using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Gem : MonoBehaviour
{
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
        get { return Range; }
        protected set { Range = value; }
    }
    public float AttackSpeed {
        get { return attackSpeed; }
        protected set { attackSpeed = value; }
    }
}
