using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    private int seconds = 0;
    private float multiplier;
    private GemBuilding host;

    private float dmgCopy;
    private float attackSpeedCopy;

    public int Seconds
    {
        get { return seconds; }
        set
        {
            seconds = value;
            if (seconds <= 0)
            {
                host.Gem.Damage = dmgCopy;
                host.Gem.AttackSpeed = attackSpeedCopy;
                Destroy(this);
            }
        }
    }
    public float Multiplier { get => multiplier; set => multiplier = value; }

    void Start()
    {
        InvokeRepeating("DecreaseDuration", 1f, 1f);
        host = GetComponent<GemBuilding>();
        dmgCopy = host.Gem.Damage;
        attackSpeedCopy = host.Gem.AttackSpeed;
        host.Gem.Damage *= 1 + Multiplier;
        host.Gem.AttackSpeed *= 1 + multiplier;
    }

    private void DecreaseDuration()
    {
        Seconds--;
    }
}
