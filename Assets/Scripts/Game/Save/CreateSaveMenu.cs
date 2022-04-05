using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;

public class CreateSaveMenu : MonoBehaviour
{
    public GameObject UserWarningPrompt;
    public Button YesButton;
    public Button NoButton;

    private string saveName;
    private bool overwrite = false;

    public void SetSaveName(string s)
    {
        saveName = s;
    }

    public void CreateSaveGame(string fileName)
    {
        StartCoroutine(CreateSaveGameCoroutine(fileName));
    }

    private IEnumerator CreateSaveGameCoroutine(string fileName)
    {
        if (SaveSystem.CheckIfFileExists(fileName))
        {
            UserWarningPrompt.gameObject.SetActive(true);
            yield return WaitForButtonPress();
            UserWarningPrompt.gameObject.SetActive(false);
            if (overwrite)
            {
                SaveSystem.CreateSaveFile(fileName, saveName);
            }
        }
        else
        {
            SaveSystem.CreateSaveFile(fileName, saveName);
        }

    }
    private IEnumerator WaitForButtonPress()
    {
        overwrite = false;
        var waitForButton = new WaitForUIButtons(YesButton, NoButton);
        yield return waitForButton.Reset();
        if (waitForButton.PressedButton == YesButton)
        {
            overwrite = true;
        }
        else
        {
            overwrite = false;
        }
    }
}
