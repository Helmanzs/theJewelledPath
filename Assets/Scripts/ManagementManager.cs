using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementManager : SceneSingleton<ManagementManager>
{
    public StructureBuildingManagement<TileChecker> structureBuildingManagement = new StructureBuildingManagement<TileChecker>();
    public GemManagement<Transform> gemManagement = new GemManagement<Transform>();

    private void Awake()
    {
        structureBuildingManagement.Awake();
        gemManagement.Awake();

    }
    private void Update()
    {
        structureBuildingManagement.Update();
        gemManagement.Update();
    }
}
