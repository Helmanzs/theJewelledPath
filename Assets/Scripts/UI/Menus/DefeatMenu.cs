using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour
{
    public static bool Defeated = false;
    public GameObject DefeatMenuUI;
    void Update()
    {
        if (Global.Instance.Mana < 0)
        {
            Defeated = true;
            GameDefeat();
        }
    }

    private void GameDefeat()
    {
        DefeatMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("TestLevel");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");

    }
    public void Exit()
    {
        Application.Quit();
    }
}
