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
        SceneManager.LoadScene(2);
    }
    public void Menu()
    {
        SceneManager.LoadScene(1);

    }
    public void Exit()
    {
        Application.Quit();
    }
}
