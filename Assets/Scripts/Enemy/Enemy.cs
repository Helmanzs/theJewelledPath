using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp = 50;
    [SerializeField] private int dmg = 20;
    [SerializeField] private int speed = 1;

    public int Speed
    {
        get { return speed; }
        set
        {
            speed = (value < 0) ? 0 : value;
        }
    }
    public int Damage => dmg;

    private void Awake()
    {
        GetComponent<NavMeshAgent>().speed = speed;
    }
    private void Update()
    {
        if (hp <= 0)
        {
            Kill();
        }
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
