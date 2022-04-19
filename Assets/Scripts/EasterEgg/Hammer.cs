using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    private void Start()
    {
        if (Time.time > 1.5f)
        {
            StartCoroutine(KillEnemies());
            Destroy(gameObject, 2f);
        }
    }
    private IEnumerator KillEnemies()
    {
        yield return new WaitForSeconds(1f);
        for (int i = Global.Instance.enemies.Count - 1; i > 0; i--)
        {
            Global.Instance.enemies[i].Kill();
        }
    }
}