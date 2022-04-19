using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarManager : MonoBehaviour
{
    public Image healthImage;
    private Enemy enemy;
    private float health;
    private float startHealth;
    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
        enemy.UnitTakenDamage += OnUnitTakenDamage;
        startHealth = enemy.HP;
        health = startHealth;
    }

    private void Update()
    {
        LookAtCamera();
    }
    private void LookAtCamera()
    {
        Vector3 v = Camera.main.transform.position - transform.position;
        v.x = v.z = 0f;
        transform.LookAt(Camera.main.transform.position - v);
    }
    private void OnUnitTakenDamage(float damage)
    {
        health -= damage;
        healthImage.fillAmount = health / startHealth;
    }
}
