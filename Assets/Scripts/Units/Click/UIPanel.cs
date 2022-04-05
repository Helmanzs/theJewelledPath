using System;
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
    public TMP_Dropdown MethodDropdown;
    public TextMeshProUGUI MissingGemText;

    private RectTransform parentRectTransform;
    private RectTransform panelRectTransform;
    private DropdownHandler dropdownHandler;
    private Structure currentStructure;
    private void Start()
    {
        parentRectTransform = GetComponent<RectTransform>();
        panelRectTransform = Panel.GetComponent<RectTransform>();
        dropdownHandler.OnValueChanged += OnDropdownValueChanged;
    }
    public void OnEnable()
    {
        ClickManager.CloseAllPanels += ClosePanel;
        dropdownHandler = MethodDropdown.GetComponent<DropdownHandler>();
    }
    private void OnDisable()
    {
        ClickManager.CloseAllPanels -= ClosePanel;
    }
    public void OpenPanel(UnitStatDataHolder data)
    {
        //if (data.Structure.GetType().IsGenericType && data.Structure.GetType().GetGenericTypeDefinition() == typeof(ISingleTargetStructure<>)) { }

        ClickManager.CallCloseAllPanels();
        Panel.gameObject.SetActive(true);
        currentStructure = data.Structure;
        TitleText.text = data.Name;
        if (data.Damage != 0)
        {
            ActivateElements();
            DamageText.text = $"Damage: {data.Damage}";
            RangeText.text = $"Range: {data.Range}";
            AttackSpeedText.text = $"Attack Speed: {data.AttackSpeed:0.00}/s";
            dropdownHandler.SetDropdownValue(data.Structure.GetComponent<TargetStateManager>().TargetMethodPointer);
        }
        else
        {
            DeactivateElements();
        }

        PositionPanel(data.MousePos);
    }

    private void ActivateElements()
    {
        DamageText.gameObject.SetActive(true);
        RangeText.gameObject.SetActive(true);
        AttackSpeedText.gameObject.SetActive(true);
        MethodDropdown.gameObject.SetActive(true);
        MissingGemText.gameObject.SetActive(false);
    }

    private void DeactivateElements()
    {
        DamageText.gameObject.SetActive(false);
        RangeText.gameObject.SetActive(false);
        AttackSpeedText.gameObject.SetActive(false);
        MethodDropdown.gameObject.SetActive(false);
        MissingGemText.gameObject.SetActive(true);
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
            pos.y = parentRectTransform.rect.height - panelHeight * 2.4f;
        Panel.position = transform.TransformPoint(pos);
    }

    private void OnDropdownValueChanged(TargetMethod method)
    {
        currentStructure.SetMethod(method);
    }

}
