using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellManager : MonoBehaviour
{
    private void Start()
    {

        //GameObject.Find("KillEnemy").GetComponent<Button>().onClick.AddListener(delegate { UseSpellOnAllEnemies("KillEnemy", new List<object> { }); });
    }

    public void UseSpellOnAllEnemies(string spell, List<object> parms)
    {
        for (int i = Global.enemies.Count - 1; i >= 0; i--)
        {
            GameObject enemy = Global.enemies[i];
            parms.Insert(0, enemy);
            StartCoroutine(spell, parms);
            parms.RemoveAt(0);
        }
    }

    public IEnumerator SlowEnemy(List<object> parms)
    {
        GameObject enemy = parms[0] as GameObject;
        float slow = (float)parms[1];
        float tempSpeed = 0;
        if (enemy != null)
        {
            tempSpeed = enemy.GetComponent<Enemy>().Speed;
            enemy.GetComponent<Enemy>().Speed -= slow;
        }
        yield return new WaitForSeconds(5f);
        if (enemy != null)
        {
            enemy.GetComponent<Enemy>().Speed = tempSpeed;
        }
    }
    public IEnumerator KillEnemy(List<object> parms)
    {
        GameObject enemy = parms[0] as GameObject;
        enemy.GetComponent<Enemy>().Kill();
        yield return null;
    }
}
