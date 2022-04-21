using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningGem : Gem
{
    void Awake()
    {
        damage = 7;
        range = 1;
        attackSpeed = 150;
        Color = transform.GetComponent<Renderer>().material.color;
        Effect = new LightningEffect();
    }
}
