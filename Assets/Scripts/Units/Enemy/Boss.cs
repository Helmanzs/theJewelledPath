using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    protected override void Start()
    {
        base.Start();

        HP = 500;
        Damage = 1;
        Speed = 5;
        Reward = 10000;
        DefaultSpeed = Speed;

    }

    protected override void Awake()
    {
        base.Awake();

        HP = 500;
        Damage = 1;
        Speed = 5;
        Reward = 10000;
        DefaultSpeed = Speed;

    }
}
