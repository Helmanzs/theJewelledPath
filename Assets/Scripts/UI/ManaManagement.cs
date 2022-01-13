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
        mana.text = Global.Instance.Mana.ToString();
    }

}
