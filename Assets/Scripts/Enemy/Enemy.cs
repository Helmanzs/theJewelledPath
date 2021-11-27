using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp = 50;
    [SerializeField] private int dmg = 20;
    [SerializeField] private int speed = 10;

    private void Update()
    {
        if (hp <= 0)
        {
            Kill();
        }

        GetComponent<NavMeshAgent>().speed = speed;
    }
    public void ApplyDamage(int damage)
    {
        hp = hp - damage;
    }
    public void Kill()
    {
        Destroy(transform.gameObject);
    }
}
