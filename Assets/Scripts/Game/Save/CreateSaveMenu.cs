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
    public GameObject ErrorBackground;
    public TextMeshProUGUI ErrorText;
    public Button OkError;
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
    private float cooldown;

    private void Awake()
    {
        overwrite = false;
        CheckFiles();
    }

    private void OnEnable()
    {
        overwrite = false;
        CheckFiles();
    }
    private void Update()
    {
        if (cooldown >= Time.time)
        {
            CheckFiles();
            cooldown = Time.time + 1;

        }
    }

    private void CheckFiles()
    {
        if (SaveSystem.CheckIfFileExists("save1"))
        {
            Save1Text.text = SaveSystem.LoadData("save1").saveName;
            Save1.interactable = true;
        }
        else
        {
            Save1Text.text = "Empty Save";
        }
        if (SaveSystem.CheckIfFileExists("save2"))
        {
            Save2Text.text = SaveSystem.LoadData("save2").saveName;
            Save2.interactable = true;
        }
        else
        {
            Save2Text.text = "Empty Save";
        }
        if (SaveSystem.CheckIfFileExists("save3"))
        {
            Save3Text.text = SaveSystem.LoadData("save3").saveName;
            Save3.interactable = true;
        }
        else
        {
            Save3Text.text = "Empty Save";
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
            StartCoroutine(DisplayError("Fill out name before creating a save."));
            return;
        }
        StartCoroutine(CreateSaveGameCoroutine(fileName));
    }

    private IEnumerator CreateSaveGameCoroutine(string fileName)
    {

        if (!SaveSystem.CheckIfFolderExists) SaveSystem.CreateSaveFolder();

        overwrite = false;
        if (SaveSystem.CheckIfFileExists(fileName))
        {
            UserWarningPrompt.gameObject.SetActive(true);
            yield return WaitForButtonPress(YesButton, NoButton);
            UserWarningPrompt.gameObject.SetActive(false);
            if (overwrite)
            {
                Player.Instance.Clear();
                Player.Instance.saveName = saveName;
                Player.Instance.fileName = fileName;
                SaveSystem.SavePlayer(fileName);
            }
            else
            {
                yield break;
            }
        }
        else
        {
            Player.Instance.Clear();
            Player.Instance.saveName = saveName;
            Player.Instance.fileName = fileName;
            SaveSystem.SavePlayer(fileName);
        }
        PlayerPrefs.SetString("lastGame", fileName);
        print(PlayerPrefs.GetString("lastGame"));
        SceneLoader.Instance.LoadScene(SceneLoader.Instance.GameMenu);
    }

    private IEnumerator DisplayError(string message)
    {
        ErrorBackground.gameObject.SetActive(true);
        ErrorText.text = message;
        yield return WaitForButtonPress(OkError);
        ErrorBackground.gameObject.SetActive(false);
    }

    private IEnumerator WaitForButtonPress(Button b1, Button b2)
    {
        overwrite = false;
        var waitForButton = new WaitForUIButtons(b1, b2);
        yield return waitForButton.Reset();
        if (waitForButton.PressedButton == b1)
        {
            overwrite = true;
        }
        else
        {
            overwrite = false;
        }
    }
    private IEnumerator WaitForButtonPress(Button b1)
    {
        var waitForButton = new WaitForUIButtons(b1);
        yield return waitForButton.Reset();
        if (waitForButton.PressedButton == b1)
        {
            yield return null;
        }
    }
}
