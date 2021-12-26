using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReactions : MonoBehaviour
{
    public void AddGem(Gem gem)
    {
        ManagementManager.Instance.gemManagement.AddGem(gem);
    }

    public void AddStructure(Structure structure)
    {
        ManagementManager.Instance.structureBuildingManagement.AddStructure(structure);

    }
}
