using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonGem : Gem
{
    void Awake()
    {
        damage = 9;
        range = 1;
        attackSpeed = 110;
        Color = transform.GetComponent<Renderer>().material.color;
        Effect = new PoisonEffect();
    }
}
