using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGem : Gem
{
    void Start()
    {
        Damage = 50;
        Range = 10;
        AttackSpeed = 100;
    }

    void Awake()
    {
        Damage = 50;
        Range = 10;
        AttackSpeed = 100;
    }
}
