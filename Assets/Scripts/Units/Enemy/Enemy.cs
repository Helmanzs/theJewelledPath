using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class Enemy : Unit
{
    [SerializeField] private Image enemySprite;
    private float hp = 0;
    private float damage = 0;
    private float speed = 0;
    private float reward = 0;

    public float Speed
    {
        get { return speed; }
        set
        {
            speed = (value < 0) ? 0 : value;
            GetComponent<NavMeshAgent>().speed = speed;
        }
    }

    public float Reward
    {
        get { return reward; }
        protected set
        {
            reward = value;
        }
    }

    public float HP
    {
        get { return hp; }
        protected set
        {
            hp = value;
            if (hp <= 0)
            {
                Kill();
            }
        }
    }

    public float Damage
    {
        get { return damage; }
        protected set
        {
            damage = value;
        }
    }

    public Image EnemySprite { get => enemySprite; private set => enemySprite = value; }

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
        Global.enemies.Remove(this);
        Global.Mana += (int)Reward;
        Destroy(transform.gameObject);
    }

    public override string ToString()
    {
        return $"Damage: {Damage}, HP: {HP}, Speed: {Speed}, Reward: {Reward}";
    }
}
