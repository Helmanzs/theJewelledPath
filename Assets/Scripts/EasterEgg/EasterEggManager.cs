using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggManager : MonoBehaviour
{
    public GameObject hammer;
    private bool used = false;
    void Update()
    {
        if (used) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(hammer, new Vector3(34, 14, 56), Quaternion.identity);
            used = true;
        }
    }
}
