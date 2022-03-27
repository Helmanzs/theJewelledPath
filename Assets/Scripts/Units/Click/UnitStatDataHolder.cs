using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct UnitStatDataHolder
{
    public string Name;
    public string Damage;
    public string Range;
    public string AttackSpeed;
    public Vector3 MousePos;

    public UnitStatDataHolder(string name, float damage, float range, float attackSpeed, Vector3 mousePos)
    {
        Name = name;
        Damage = damage.ToString();
        Range = (range / 2).ToString();
        if (attackSpeed == 0)
        {
            AttackSpeed = "0";
        }
        else
        {
            AttackSpeed = (2 / (1 + attackSpeed / 100)).ToString("0.00");

        }
        MousePos = mousePos;
    }
}