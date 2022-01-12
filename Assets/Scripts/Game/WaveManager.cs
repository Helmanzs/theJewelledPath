using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveManager : MonoBehaviour
{
    [Header("Enemies")]
    public BasicEnemy basicEnemy;

    private bool ready = true;
    private float nextTimeCall;
    private Transform ENEMIES;

    private void Start()
    {
        ENEMIES = GameObject.Find("ENEMIES").transform;
        nextTimeCall = Time.time + .1f;
    }

    void Update()
    {
        if (ready == true)
        {
            StartCoroutine(SpawnEnemies(10, basicEnemy));
        }
        if (Time.time >= nextTimeCall)
        {
            nextTimeCall += .1f;
        }

    }

    IEnumerator SpawnEnemies(int number, Enemy type)
    {
        ready = false;
        for (int i = 0; i < number; i++)
        {
            Enemy enemy = Instantiate(type, new Vector3(Global.spawnTile.transform.position.x, 1, Global.spawnTile.transform.position.z), Quaternion.identity);
            float delay = enemy.Speed / 10f;
            Global.enemies.Add(enemy);
            enemy.transform.SetParent(ENEMIES);
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(5f);
        ready = true;


    }
}
