using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonDamageOverTime : MonoBehaviour
{
    public float Multiplier { get; set; }
    public float Seconds { get; set; }
    public float ApplyEveryNSeconds { get; set; }

    private float damage;

    private Enemy host;

    private int appliedTimes = 0;

    void Start()
    {
        host = GetComponent<Enemy>();
        damage = (host.HP * 0.05f) * (1 + Multiplier);
        StartCoroutine(Dps());
    }

    IEnumerator Dps()
    {
        while (appliedTimes < 5)
        {
            host.ApplyDamage(damage);
            yield return new WaitForSeconds(ApplyEveryNSeconds);
            appliedTimes++;
        }

        Destroy(this);
    }
}

