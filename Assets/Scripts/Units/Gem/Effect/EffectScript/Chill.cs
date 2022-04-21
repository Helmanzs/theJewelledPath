using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chill : MonoBehaviour
{
    private int seconds = 0;
    private float multiplier;
    private Enemy host;

    public int Seconds
    {
        get { return seconds; }
        set
        {
            seconds = value;
            if (seconds <= 0)
            {
                host.Speed = host.DefaultSpeed;
                Destroy(this);
            }
        }
    }
    public float Multiplier { get => multiplier; set => multiplier = value; }

    void Start()
    {
        InvokeRepeating("DecreaseDuration", 1f, 1f);
        host = GetComponent<Enemy>();
        float slowdown = 1 - multiplier <= 0 ? 0 : 1 - multiplier;
        host.Speed = host.DefaultSpeed * slowdown;
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
