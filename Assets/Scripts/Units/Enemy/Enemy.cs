using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public abstract class Enemy : Unit
{
    public event Action<float> UnitTakenDamage;

    [SerializeField] private Image enemySprite;
    [SerializeField] private float hp = 50;
    [SerializeField] private float damage = 100;
    [SerializeField] private float speed = 10;
    [SerializeField] private float reward = 500;
    [SerializeField] private float defaultSpeed = 10;


    private NavMeshAgent agent;

    public float Speed
    {
        get { return speed; }
        set
        {
            speed = (value < 0) ? 0 : value;
            agent.speed = speed;
        }
    }
    public float DefaultSpeed { get; protected set; }

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
        set
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

    public Image EnemySprite { get => enemySprite; protected set => enemySprite = value; }

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    public void OnMouseDown()
    {
        CameraController.Instance.followTransform = transform;
    }
    public void ApplyDamage(float damage)
    {
        UnitTakenDamage?.Invoke(damage);
        HP -= damage;
    }
    public void Kill()
    {
        Global.Instance.enemies.Remove(this);
        Global.Instance.Mana += (int)Reward;
        Destroy(transform.gameObject);
    }
    public override string ToString()
    {
        return $"Damage: {Damage}, HP: {HP}, Speed: {Speed}, Reward: {Reward}, Type: {this.GetType()}";
    }
}
