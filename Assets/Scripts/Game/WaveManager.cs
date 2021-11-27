using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveManager : MonoBehaviour
{
    public GameObject basicEnemy;
    List<GameObject> enemies = new List<GameObject>();
    private bool ready = true;

    // Update is called once per frame
    void Update()
    {
        if (ready == true)
        {
            StartCoroutine(SpawnEnemies(10, basicEnemy));
        }

    }

    IEnumerator SpawnEnemies(int number, GameObject type)
    {
        ready = false;
        for (int i = 0; i < number; i++)
        {
            yield return new WaitForSeconds(type.GetComponent<NavMeshAgent>().speed / 100);
            GameObject enemy = Instantiate(type, new Vector3(Global.spawnTile.transform.position.x, 1, Global.spawnTile.transform.position.z), Quaternion.identity);
            enemies.Add(enemy);
        }
        yield return new WaitForSeconds(10f);
        ready = true;


    }
}
