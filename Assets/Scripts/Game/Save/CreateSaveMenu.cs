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

    public Button Save1;
    public TextMeshProUGUI Save1Text;
    public Button Save2;
    public TextMeshProUGUI Save2Text;
    public Button Save3;
    public TextMeshProUGUI Save3Text;

    private string saveName;
    private bool overwrite = false;

    private void Awake()
    {
        if (SaveSystem.CheckIfFileExists("save1"))
        {
            Save1Text.text = SaveSystem.LoadData("save1").saveName;
            Save1.interactable = true;
        }
        if (SaveSystem.CheckIfFileExists("save2"))
        {
            Save2Text.text = SaveSystem.LoadData("save2").saveName;
            Save2.interactable = true;
        }
        if (SaveSystem.CheckIfFileExists("save3"))
        {
            Save3Text.text = SaveSystem.LoadData("save3").saveName;
            Save3.interactable = true;
        }
    }

    public void SetSaveName(string s)
    {
        saveName = s;
    }

    public void CreateSaveGame(string fileName)
    {
        if (saveName == "" || saveName == null)
        {
            Debug.LogError("Name must not be empty!");
            return;
        }
        StartCoroutine(CreateSaveGameCoroutine(fileName));
    }

    private IEnumerator CreateSaveGameCoroutine(string fileName)
    {

        if (!SaveSystem.CheckIfFolderExists) SaveSystem.CreateSaveFolder();

        if (SaveSystem.CheckIfFileExists(fileName))
        {
            UserWarningPrompt.gameObject.SetActive(true);
            yield return WaitForButtonPress();
            UserWarningPrompt.gameObject.SetActive(false);
            if (overwrite)
            {
                Player.Instance.Clear();
                Player.Instance.saveName = saveName;
                SaveSystem.SavePlayer(fileName);
            }
        }
        else
        {
            Player.Instance.Clear();
            Player.Instance.saveName = saveName;
            SaveSystem.SavePlayer(fileName);
        }
        PlayerPrefs.SetString("lastGame", fileName);
        SceneLoader.Instance.LoadScene(SceneLoader.Instance.GameMenu);
        print(PlayerPrefs.GetString("lastGame"));
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
