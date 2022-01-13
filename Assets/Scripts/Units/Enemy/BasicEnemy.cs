using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();

        HP = 50;
        Damage = 20;
        Speed = 10;
        Reward = 500;
    }

    protected override void Awake()
    {
        base.Awake();

        HP = 50;
        Damage = 20;
        Speed = 10;
        Reward = 500;

    }
}
