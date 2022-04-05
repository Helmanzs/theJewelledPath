using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMenu : MonoBehaviour
{
    public void LoadPlayer(string fileName)
    {
        PlayerPrefs.SetString("lastGame", fileName);
        print(fileName);
    }
}
