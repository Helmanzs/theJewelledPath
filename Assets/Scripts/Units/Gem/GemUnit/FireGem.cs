using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGem : Gem
{
    void Awake()
    {
        damage = 12;
        range = 1;
        attackSpeed = 90;
        Color = transform.GetComponent<Renderer>().material.color;
        Effect = new FireEffect();
    }
}
