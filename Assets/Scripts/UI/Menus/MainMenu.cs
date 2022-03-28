using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject loadMenu;
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void ShowLoadGamePanel()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        loadMenu.SetActive(!loadMenu.activeSelf);
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
