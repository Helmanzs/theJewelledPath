using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public static bool Won = false;
    public GameObject WinMenuUI;

    public void GameWin()
    {
        WinMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Menu()
    {
        Player.Instance.SumStatistics();
        Player.Instance.ClearedLevels++;
        SaveSystem.SavePlayer(Player.Instance.fileName);
        SceneLoader.Instance.LoadScene(SceneLoader.Instance.GameMenu);

    }
    public void Exit()
    {
        Application.Quit();
    }
}
