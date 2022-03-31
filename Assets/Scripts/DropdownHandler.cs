using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownHandler : MonoBehaviour
{
    public event Action<TargetMethod> OnValueChanged;
    public TMP_Dropdown Dropdown;
    private void Start()
    {
        Dropdown.ClearOptions();
        foreach (var method in Enum.GetValues(typeof(TargetMethod)))
        {
            Dropdown.options.Add(new TMP_Dropdown.OptionData() { text = method.ToString() });
        }
        Dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(Dropdown); });//Add listener to Event

    }
    private void DropdownValueChanged(TMP_Dropdown change)
    {
        TargetMethod method = (TargetMethod)change.value; //Convert dropwdown value to enum
        OnValueChanged?.Invoke(method);
    }

    public void SetDropdownValue(TargetMethod method)
    {
        Dropdown.value = (int)method;
    }
}
