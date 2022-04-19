using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTile : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<Enemy>();
            Global.Instance.enemies.Remove(enemy);
            if (enemy is Boss)
            {
                Global.Instance.Mana = -1;
            }
            else
            {
                Global.Instance.Mana -= 1000;
            }
            Destroy(enemy.gameObject);
        }
    }
}
