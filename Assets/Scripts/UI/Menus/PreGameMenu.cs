using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreGameMenu : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneLoader.Instance.LoadScene("Menu");
    }

    public void LoadLevel(string scene)
    {
        SceneLoader.Instance.LoadScene(scene);
    }
}
