using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamageOverTime : MonoBehaviour
{
    public float Damage { get; set; }
    public float Seconds { get; set; }
    public float ApplyEveryNSeconds { get; set; }

    private Enemy host;

    private int appliedTimes = 0;

    void Start()
    {
        host = GetComponent<Enemy>();
        StartCoroutine(Dps());
    }

    IEnumerator Dps()
    {
        while (appliedTimes < 5)
        {
            host.ApplyDamage(Damage);
            yield return new WaitForSeconds(ApplyEveryNSeconds);
            appliedTimes++;
        }

        Destroy(this);
    }
}
