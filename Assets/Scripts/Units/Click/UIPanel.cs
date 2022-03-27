using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class UIPanel : SceneSingleton<UIPanel>
{
    public Transform Panel;
    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI DamageText;
    public TextMeshProUGUI RangeText;
    public TextMeshProUGUI AttackSpeedText;

    private RectTransform parentRectTransform;
    private RectTransform panelRectTransform;
    private void Start()
    {
        parentRectTransform = GetComponent<RectTransform>();
        panelRectTransform = Panel.GetComponent<RectTransform>();
    }

    public void OnEnable()
    {
        ClickManager.CloseAllPanels += ClosePanel;
    }
    private void OnDisable()
    {
        ClickManager.CloseAllPanels -= ClosePanel;
    }
    public void OpenPanel(UnitStatDataHolder data)
    {
        ClickManager.CallCloseAllPanels();
        Panel.gameObject.SetActive(true);
        PositionPanel(data.MousePos);
        TitleText.text = data.Name;
        DamageText.text = $"Damage: {data.Damage}";
        RangeText.text = $"Range: {data.Range}";
        AttackSpeedText.text = $"Attack Speed: {data.AttackSpeed}/s";
    }
    public void ClosePanel()
    {
        Panel.gameObject.SetActive(false);
    }

    private void PositionPanel(Vector3 mousePos)
    {
        Vector2 pos;
        float panelWidth = panelRectTransform.sizeDelta.x / 2;
        float panelHeight = panelRectTransform.sizeDelta.y / 2;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.GetComponent<RectTransform>(), mousePos, Camera.main, out pos);

        if (pos.x - panelWidth < 0)
            pos.x = panelWidth;
        if (pos.x + panelWidth > parentRectTransform.rect.width)
            pos.x = parentRectTransform.rect.width - panelWidth;
        if (pos.y + panelHeight * 2.4f > parentRectTransform.rect.height)
            pos.y = parentRectTransform.rect.height - panelHeight;

        Panel.position = transform.TransformPoint(pos);

    }
}
