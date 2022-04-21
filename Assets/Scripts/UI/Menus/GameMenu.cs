using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public TextMeshProUGUI PlayerName;
    public GameObject Levels1;
    public GameObject Levels2;
    public Button NextButton;
    public Button PreviousButton;
    public Button[] levels;
    public GameObject gameMenu;
    public GameObject statisticsMenu;
    public Button BackButton;
    public Button statisticsButton;
    private void Awake()
    {
        PlayerName.text = Player.Instance.saveName;
        NextButton.gameObject.SetActive(true);
        CheckClearedLevels();

    }
    private void CheckClearedLevels()
    {
        //levels[0].interactable = true;
        print(Player.Instance.ClearedLevels);
        for (int i = 0; i < Player.Instance.ClearedLevels; i++)
        {
            levels[i].interactable = true;
        }
    }
    public void BackToMainMenu()
    {
        SaveSystem.SavePlayer(Player.Instance.fileName);
        SceneLoader.Instance.LoadScene(SceneLoader.Instance.MainMenu);
    }

    public void LoadLevel(string scene)
    {
        SceneLoader.Instance.LoadScene(scene);
    }

    public void NextLevels()
    {
        Levels1.SetActive(false);
        Levels2.SetActive(true);
        NextButton.gameObject.SetActive(false);
        PreviousButton.gameObject.SetActive(true);
    }

    public void PreviousLevels()
    {

        Levels1.SetActive(true);
        Levels2.SetActive(false);
        NextButton.gameObject.SetActive(true);
        PreviousButton.gameObject.SetActive(false);
    }

    public void ShowStatistics()
    {
        gameMenu.SetActive(!gameMenu.activeSelf);
        statisticsMenu.SetActive(!statisticsMenu.activeSelf);
    }
}
