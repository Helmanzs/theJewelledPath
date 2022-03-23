using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulnerable : MonoBehaviour
{
    private Enemy host;
    public float multiplier;
    private int seconds;
    public int Seconds
    {
        get { return seconds; }
        set
        {
            seconds = value;
            if (seconds <= 0)
            {
                Destroy(this);
            }
        }
    }

    void Start()
    {
        InvokeRepeating("DecreaseDuration", 1f, 1f);
        host = GetComponent<Enemy>();
        host.UnitTakenDamage += MultiplyDamage;
    }

    private void MultiplyDamage(float damage)
    {
        host.HP -= damage * (1 + multiplier);
    }

    private void DecreaseDuration()
    {
        Seconds--;
    }

    public void RefreshDuration(int duration)
    {
        this.Seconds = duration;
    }


}
