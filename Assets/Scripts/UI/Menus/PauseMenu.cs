using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        Player.Instance.SumStatistics();
        SaveSystem.SavePlayer(Player.Instance.fileName);
        SceneLoader.Instance.LoadScene(SceneLoader.Instance.GameMenu);

    }
    public void Exit()
    {
        Application.Quit();
    }


}
