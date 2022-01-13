using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StructureBuildingManagement<T> : BuildingManagement<T> where T : MonoBehaviour
{
    public void AddStructure(Structure structure)
    {
        if (Global.Instance.Mana - (int)structure.cost >= 0)
        {
            if (Unit != null)
            {
                DeleteShowcasedUnit();
            }
            Unit = GameObject.Instantiate(structure, new Vector3(0, 0, 0), Quaternion.identity);
            Unit.gameObject.SetActive(false);
            UnitPreview = GameObject.Instantiate(((Structure)Unit).previewUnit, new Vector3(0, 0, 0), Quaternion.identity);
            UnitPreview.gameObject.SetActive(false);
            buildingMode = true;
        }
    }

    protected override void PreviewUnit()
    {
        if (selector.GetObject(1 << 7, "EmptyBuildingSpot") != null)
        {
            T previewedSpot = selector.GetObject(1 << 7, "EmptyBuildingSpot");
            TileChecker spot = previewedSpot as TileChecker;
            if (spot.Structure == null)
            {
                if (spot != lastPlace)
                {
                    ShowcaseUnit(spot as T);
                    lastPlace = previewedSpot;
                }
            }
        }
    }

    protected override void AddUnit(T place)
    {
        if (place != default(T))
        {
            TileChecker spot = place as TileChecker;
            spot.Structure = Unit as Structure;
            Global.Instance.Mana -= (int)spot.Structure.cost;
            Unit.transform.position = spot.transform.position;
            Unit.gameObject.SetActive(true);
            if (Unit is GemBuilding)
            {
                Global.Instance.gemBuildings.Add(Unit as GemBuilding);
            }
            else
            {
                Global.Instance.buildings.Add(Unit as Structure);
            }
            Unit.transform.SetParent(spot.transform);
            Unit = null;
            GameObject.Destroy(UnitPreview.gameObject);
            buildingMode = false;
        }
    }
    protected override void DeleteUnit(T place, T unit)
    {
    }

    protected override void ShowcaseUnit(T place)
    {
        TileChecker spot = place as TileChecker;
        UnitPreview.gameObject.SetActive(true);
        UnitPreview.transform.SetParent(spot.transform);
        UnitPreview.transform.localPosition = new Vector3(0, 0, 0);
    }
}
