using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StructureBuildingManagement<T> : BuildingManagement<T> where T : MonoBehaviour
{
    public void Update()
    {
        if (structureBuildingMode)
        {
            PreviewUnit();
            if (Input.GetMouseButton(0))
            {
                AddUnit(lastPlace);
            }
            else if (Input.GetMouseButton(1))
            {
                if (lastPlace != null)
                {
                    DeleteShowcasedUnit();
                }
            }
        }
    }

    public void AddStructure(Structure structure)
    {
        Unit = GameObject.Instantiate(structure, new Vector3(0, 0, 0), Quaternion.identity);
        Unit.gameObject.SetActive(false);
        UnitPreview = GameObject.Instantiate(((Structure)Unit).previewUnit, new Vector3(0, 0, 0), Quaternion.identity);
        UnitPreview.gameObject.SetActive(false);
        structureBuildingMode = true;
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
        TileChecker spot = place as TileChecker;
        spot.Structure = Unit as Structure;
        Unit.transform.position = spot.transform.position;
        Unit.gameObject.SetActive(true);
        Global.buildings.Add(Unit as Structure);
        Unit.transform.SetParent(spot.transform);
        GameObject.Destroy(UnitPreview.gameObject);
        Unit = null;
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
