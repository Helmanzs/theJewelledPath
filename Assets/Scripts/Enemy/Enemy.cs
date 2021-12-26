using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private float hp = 50;
    private float dmg = 20;
    private float speed = 10;

    public float Speed
    {
        get { return speed; }
        set
        {
            speed = (value < 0) ? 0 : value;
            GetComponent<NavMeshAgent>().speed = speed;
        }
    }

    public float HP
    {
        get { return hp; }
        private set
        {
            hp = value;
            if (hp <= 0)
            {
                Kill();
            }
        }
    }

    public float Damage => dmg;

    private void Awake()
    {
        GetComponent<NavMeshAgent>().speed = speed;
    }

    public void ApplyDamage(float damage)
    {
        HP -= damage;
    }
    public void Kill()
    {
        Global.enemies.Remove(this.gameObject);
        Destroy(transform.gameObject);
    }
}
