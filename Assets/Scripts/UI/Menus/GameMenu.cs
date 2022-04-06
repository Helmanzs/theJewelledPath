using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMenu : MonoBehaviour
{
    public TextMeshProUGUI PlayerName;
    private void Awake()
    {
        PlayerName.text = Player.Instance.saveName;
    }
    public void BackToMainMenu()
    {
        SceneLoader.Instance.LoadScene(SceneLoader.Instance.MainMenu);
    }

    public void LoadLevel(string scene)
    {
        SceneLoader.Instance.LoadScene(scene);
    }
}
