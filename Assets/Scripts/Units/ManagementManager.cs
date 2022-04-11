using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementManager : SceneSingleton<ManagementManager>
{
    public StructureBuildingManagement<BuildingSpot> structureBuildingManagement = new StructureBuildingManagement<BuildingSpot>();
    public GemManagement<GemBuilding> gemManagement = new GemManagement<GemBuilding>();

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
