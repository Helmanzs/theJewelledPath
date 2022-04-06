using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject loadMenu;
    public GameObject createSaveMenu;

    public GameObject CreateGame;
    public GameObject PlayGame;
    private void Awake()
    {

        if (!SaveSystem.CheckIfFolderContainsFiles(new string[] { "save1", "save2", "save3" }))
        {
            CreateGame.SetActive(true);
            PlayGame.SetActive(false);
        }
        else
        {
            SaveSystem.LoadPlayer(PlayerPrefs.GetString("lastGame"));
        }

    }
    public void Play()
    {
        SceneLoader.Instance.LoadScene(SceneLoader.Instance.GameMenu);
    }
    public void ShowLoadGamePanel()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        loadMenu.SetActive(!loadMenu.activeSelf);
    }
    public void ShowCreateSavePanel()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        createSaveMenu.SetActive(!createSaveMenu.activeSelf);
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
