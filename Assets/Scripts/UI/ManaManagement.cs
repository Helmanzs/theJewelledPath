using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManagement : MonoBehaviour
{
    public Text mana;

    private float nextTimeCall = 0;

    void Update()
    {
        if (nextTimeCall < Time.time)
        {
            nextTimeCall = Time.time + 1;
            Global.Mana += 100;
        }
        mana.text = Global.Mana.ToString();
    }

}
