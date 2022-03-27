using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    public TMP_Dropdown Dropdown;
    private void Start()
    {
        Dropdown.ClearOptions();
        foreach (var method in Enum.GetValues(typeof(TargetMethod)))
        {
            Dropdown.options.Add(new TMP_Dropdown.OptionData() { text = method.ToString() });
        }
    }
}
