using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct UnitStatDataHolder
{
    public Structure Structure;
    public string Name;
    public float Damage;
    public float Range;
    public float AttackSpeed;
    public Vector3 MousePos;

    public UnitStatDataHolder(Structure structure, string name, float damage, float range, float attackSpeed, Vector3 mousePos)
    {
        Structure = structure;
        Name = name;
        Damage = damage;
        Range = (range / 2);
        AttackSpeed = (2 / (1 + attackSpeed / 100));
        MousePos = mousePos;
    }
}