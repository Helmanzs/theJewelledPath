using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadMenu : MonoBehaviour
{
    public Button Save1;
    public TextMeshProUGUI Save1Text;
    public Button Save2;
    public TextMeshProUGUI Save2Text;
    public Button Save3;
    public TextMeshProUGUI Save3Text;

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
    public void LoadPlayer(string fileName)
    {
        SaveSystem.LoadPlayer(fileName);
        PlayerPrefs.SetString("lastGame", fileName);
        SceneLoader.Instance.LoadScene(SceneLoader.Instance.GameMenu);
    }
}
