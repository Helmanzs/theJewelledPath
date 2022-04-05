using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject loadMenu;
    public GameObject startGameButton;
    public GameObject createGameButton;
    public GameObject loadButton;
    private void Awake()
    {
        if (!SaveSystem.CheckIfFolderExists)
        {
            startGameButton.SetActive(false);
            createGameButton.SetActive(true);
        }
    }
    public void Play()
    {
        SceneLoader.Instance.LoadScene("PreGame");
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
