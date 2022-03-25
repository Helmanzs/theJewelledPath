using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : SceneSingleton<UIPanel>
{
    public Transform Panel;
    public void OnEnable()
    {
        ClickManager.CloseAllPanels += ClosePanel;
    }
    private void OnDisable()
    {
        ClickManager.CloseAllPanels -= ClosePanel;
    }
    public void OpenPanel()
    {
        ClickManager.CallCloseAllPanels();
        Panel.gameObject.SetActive(true);
    }
    public void ClosePanel()
    {
        Panel.gameObject.SetActive(false);
    }
}
