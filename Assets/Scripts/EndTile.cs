using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTile : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Global.Mana = Global.Mana - 1000;
            
        }
    }
}
