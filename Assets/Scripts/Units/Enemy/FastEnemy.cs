using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{

    protected override void Start()
    {
        base.Start();

        HP = 30;
        Damage = 15;
        Speed = 20;
        Reward = 750;
        DefaultSpeed = Speed;

    }

    protected override void Awake()
    {
        base.Awake();

        HP = 30;
        Damage = 15;
        Speed = 20;
        Reward = 750;
        DefaultSpeed = Speed;
    }
}

