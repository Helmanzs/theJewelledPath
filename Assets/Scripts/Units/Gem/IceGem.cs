using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGem : Gem
{
    void Awake()
    {
        Damage = 10;
        Range = 10;
        AttackSpeed = 100;
        Color = transform.GetComponent<Renderer>().material.color;
        Effect = GetComponent<Effect>();
    }
}
