using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMenu : MonoBehaviour
{
    public TextMeshProUGUI PlayerName;
    public GameObject Levels1;
    public GameObject Levels2;
    public GameObject NextButton;
    public GameObject PreviousButton;
    private void Awake()
    {
        PlayerName.text = Player.Instance.saveName;
        NextButton.SetActive(true);

    }
    public void BackToMainMenu()
    {
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
        NextButton.SetActive(false);
        PreviousButton.SetActive(true);
    }

    public void PreviousLevels()
    {

        Levels1.SetActive(true);
        Levels2.SetActive(false);
        NextButton.SetActive(true);
        PreviousButton.SetActive(false);
    }
}
