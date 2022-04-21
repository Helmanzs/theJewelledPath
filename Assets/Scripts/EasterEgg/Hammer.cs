using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public ParticleSystem particles;
    private void Start()
    {
        if (Time.time > 1.5f)
        {
            StartCoroutine(KillEnemies());
        }
    }
    private IEnumerator KillEnemies()
    {
        yield return new WaitForSeconds(1f);
        if (Global.Instance.enemies.Count > 0)
        {
            for (int i = Global.Instance.enemies.Count - 1; i >= 0; i--)
            {
                Global.Instance.enemies[i].Kill();
            }
        }
        particles.Play();
        Destroy(gameObject, 2f);
    }
}