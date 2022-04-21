using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaGem : Gem
{
    void Awake()
    {
        damage = 20;
        range = 1;
        attackSpeed = 50;
        Color = transform.GetComponent<Renderer>().material.color;
        Effect = new ManaStealEffect();
    }
}
