using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();

        HP = 150;
        Damage = 40;
        Speed = 8;
        Reward = 1000;
        DefaultSpeed = Speed;

    }

    protected override void Awake()
    {
        base.Awake();

        HP = 150;
        Damage = 40;
        Speed = 8;
        Reward = 1000;
        DefaultSpeed = Speed;

    }
}
