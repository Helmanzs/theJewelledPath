using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTile : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            Global.Instance.enemies.Remove(other.gameObject.GetComponent<Enemy>());
            Destroy(other.gameObject);
            Global.Instance.Mana -= 1000;

        }
    }
}
