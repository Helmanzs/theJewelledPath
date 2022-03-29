using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGem : Gem
{
    void Awake()
    {
        damage = 10;
        range = 10;
        attackSpeed = 100;
        Color = transform.GetComponent<Renderer>().material.color;
        Effect = new IceEffect();
    }
}
