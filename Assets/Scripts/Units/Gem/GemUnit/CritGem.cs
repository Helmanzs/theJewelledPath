using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritGem : Gem
{
    void Awake()
    {
        damage = 15;
        range = 1;
        attackSpeed = 80;
        Color = transform.GetComponent<Renderer>().material.color;
        Effect = new CritEffect();
    }
}
