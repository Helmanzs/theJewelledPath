using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaWriter : MonoBehaviour
{
    public Text mana;

    void Update()
    {
        Global.mana += 1;
        mana.text = Global.Mana.ToString();
    }
}
