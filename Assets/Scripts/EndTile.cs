using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("DefaultEnemy"))
        {
            Destroy(other.gameObject);
            Global.Mana = Global.Mana - 1000;
            
        }
    }
}
