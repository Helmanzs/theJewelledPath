using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour
{
    public static bool Defeated = false;
    public GameObject DefeatMenuUI;

    private string currentScene;
    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

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
        SceneManager.LoadScene(currentScene);
    }
    public void Menu()
    {
        SceneLoader.Instance.LoadScene(SceneLoader.Instance.GameMenu);

    }
    public void Exit()
    {
        Application.Quit();
    }
}
