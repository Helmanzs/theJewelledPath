using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaWriter : MonoBehaviour
{
    public Text mana;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Global.mana++;
        mana.text = Global.mana.ToString();
    }
}
