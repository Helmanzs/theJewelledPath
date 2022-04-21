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

    [Header("Amplifier mods")]
    public TextMeshProUGUI FireValue;
    public TextMeshProUGUI IceValue;
    public TextMeshProUGUI PoisonValue;
    public TextMeshProUGUI LightningValue;
    public TextMeshProUGUI ManaStealValue;
    public TextMeshProUGUI VulnerabilityValue;
    public StatisticsFieldController FireField;
    public StatisticsFieldController IceField;
    public StatisticsFieldController PoisonField;
    public StatisticsFieldController LightningField;
    public StatisticsFieldController ManaField;
    public StatisticsFieldController VulnerabilityField;

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
        if (data.Structure is Amplifier)
        {
            OpenPanelAmplifier(data);
            return;
        }

        bool isSingleTarget = false;
        if (data.Structure is Tower)
        {
            isSingleTarget = true;
        }

        ClickManager.CallCloseAllPanels();
        Panel.gameObject.SetActive(true);
        DeactivateElements();
        currentStructure = data.Structure;
        TitleText.text = data.Name;
        if (data.Damage != 0)
        {
            ActivateElements(isSingleTarget);
            DamageText.text = $"Damage: {data.Damage}";
            RangeText.text = $"Range: {data.Range}";
            AttackSpeedText.text = $"Attack Speed: {data.AttackSpeed:0.00}/s";
            if (isSingleTarget)
                dropdownHandler.SetDropdownValue(data.Structure.GetComponent<TargetStateManager>().TargetMethodPointer);
        }
        else
        {
            DeactivateElements();
        }

        PositionPanel(data.MousePos);
    }

    public void OpenPanelAmplifier(UnitStatDataHolder data)
    {
        ClickManager.CallCloseAllPanels();
        Panel.gameObject.SetActive(true);
        currentStructure = data.Structure;
        TitleText.text = data.Name;
        DeactivateElements();
        if (data.Damage != 0)
        {
            ActivateAmplifierElements();

            foreach (Tuple<Effect, float> effect in data.Effects)
            {

                if (effect.Item1 is FireEffect)
                    FireValue.text = $"{effect.Item2}";
                if (effect.Item1 is IceEffect)
                    IceValue.text = $"{effect.Item2}";
                if (effect.Item1 is LightningEffect)
                    LightningValue.text = $"{effect.Item2}";
                if (effect.Item1 is PoisonEffect)
                    PoisonValue.text = $"{effect.Item2}";
                if (effect.Item1 is ManaStealEffect)
                    ManaStealValue.text = $"{effect.Item2}";
                if (effect.Item1 is CritEffect)
                    VulnerabilityValue.text = $"{effect.Item2}";
            }
        }
        else
        {
            DeactivateElements();
        }

        PositionPanel(data.MousePos);
    }

    private void ActivateElements(bool IsSingleTarget)
    {
        DamageText.gameObject.SetActive(true);
        RangeText.gameObject.SetActive(true);
        AttackSpeedText.gameObject.SetActive(true);
        if (IsSingleTarget)
            MethodDropdown.gameObject.SetActive(true);
        MissingGemText.gameObject.SetActive(false);
    }

    private void ActivateAmplifierElements()
    {
        FireField.gameObject.SetActive(true);
        IceField.gameObject.SetActive(true);
        PoisonField.gameObject.SetActive(true);
        LightningField.gameObject.SetActive(true);
        ManaField.gameObject.SetActive(true);
        VulnerabilityField.gameObject.SetActive(true);
        MissingGemText.gameObject.SetActive(false);

    }

    private void DeactivateElements()
    {
        DamageText.gameObject.SetActive(false);
        RangeText.gameObject.SetActive(false);
        AttackSpeedText.gameObject.SetActive(false);
        MethodDropdown.gameObject.SetActive(false);
        FireField.gameObject.SetActive(false);
        IceField.gameObject.SetActive(false);
        PoisonField.gameObject.SetActive(false);
        LightningField.gameObject.SetActive(false);
        ManaField.gameObject.SetActive(false);
        VulnerabilityField.gameObject.SetActive(false);
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
