using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    private void Start()
    {
        HP = 50;
        Damage = 20;
        Speed = 10;
        Reward = 500;
    }

    private void Awake()
    {
        HP = 50;
        Damage = 20;
        Speed = 10;
        Reward = 500;
    }
}
