using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class Enemy : Unit
{
    [SerializeField] private Image enemySprite;
    private NavMeshAgent agent;
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
            agent.speed = speed;
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
                this.gameObject.SetActive(false);
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

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    public void ApplyDamage(float damage)
    {
        HP -= damage;
    }
    public void Kill()
    {
        Destroy(transform.gameObject);
        Global.Instance.enemies.Remove(this);
        Global.Instance.Mana += (int)Reward;
    }

    public override string ToString()
    {
        return $"Damage: {Damage}, HP: {HP}, Speed: {Speed}, Reward: {Reward}";
    }
}
