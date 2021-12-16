using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveManager : MonoBehaviour
{
    public GameObject basicEnemy;
    public GameObject waveInfoHolder;

    public GameObject waveInfo;
    List<GameObject> enemies = new List<GameObject>();
    private bool ready = true;
    private float nextTimeCall;

    // Update is called once per frame
    private void Start()
    {
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
            MoveWaves();
            nextTimeCall += .1f;
        }

    }
    void MoveWaves()
    {
        /*foreach (Transform waveInfo in waveInfoHolder.transform)
        {
            waveInfo.localPosition += new Vector3(0, 5f, 0);

            if (waveInfo.localPosition.y >= (waveInfoHolder.transform.localPosition + new Vector3(0f, 220f, 0f)).y)
            {
                Destroy(waveInfo.gameObject);
            }
        }*/

        //GameObject wave = Instantiate(waveInfo, -waveInfoHolder.transform.position, Quaternion.identity) as GameObject;

    }
    IEnumerator SpawnEnemies(int number, GameObject type)
    {
        ready = false;
        for (int i = 0; i < number; i++)
        {
            float delay = type.GetComponent<Enemy>().Speed / 100f;
            yield return new WaitForSeconds(delay);
            GameObject enemy = Instantiate(type, new Vector3(Global.spawnTile.transform.position.x, 1, Global.spawnTile.transform.position.z), Quaternion.identity);
            enemies.Add(enemy);
        }
        yield return new WaitForSeconds(10f);
        ready = true;


    }
}
