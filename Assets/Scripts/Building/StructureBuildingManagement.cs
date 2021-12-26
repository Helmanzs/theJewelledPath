using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StructureBuildingManagement<T> : BuildingManagement<T> where T : MonoBehaviour
{

    private GameObject preview;

    public void Update()
    {
        if (structureBuildingMode)
        {
            PreviewUnit();
            if (Input.GetMouseButton(0))
            {
                AddUnit(lastPlace);
                PreviewedUnit = null;
            }
            else if (Input.GetMouseButton(1))
            {
                if (lastPlace != null)
                {
                    DeleteShowcasedStructure();
                }
                PreviewedUnit = null;
            }
        }
    }

    public void AddStructure(Structure structure)
    {
        if (structure == null)
        {
            return;
        }

        PreviewedUnit = GameObject.Instantiate(structure, new Vector3(0, 0, 0), Quaternion.identity);
        preview = GameObject.Instantiate(((Structure)PreviewedUnit).previewStructure, new Vector3(0, 0, 0), Quaternion.identity);
        PreviewedUnit.gameObject.SetActive(false);
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
                    ShowcaseStructure(spot.gameObject);
                    lastPlace = previewedSpot;
                }
            }
        }
    }

    private void ShowcaseStructure(GameObject place)
    {
        preview.transform.SetParent(place.transform);
        preview.transform.localPosition = new Vector3(0, 0, 0);
    }
    private void DeleteShowcasedStructure()
    {
        GameObject.Destroy(preview);
        GameObject.Destroy(PreviewedUnit.gameObject);
    }
    protected override void AddUnit(T place)
    {
        TileChecker spot = place as TileChecker;
        GameObject.Destroy(preview);
        spot.Structure = PreviewedUnit as Structure;
        PreviewedUnit.transform.position = spot.transform.position;
        PreviewedUnit.gameObject.SetActive(true);
        Global.buildings.Add(PreviewedUnit as Structure);
        PreviewedUnit.transform.SetParent(spot.transform);
    }

    protected override void DeleteUnit(GameObject place, GameObject unit)
    {
        place.tag = "EmptyBuildingSpot";
        Global.buildings.Remove(place.GetComponent<TileChecker>().Structure);
        GameObject.Destroy(place.GetComponent<TileChecker>().Structure);
        place.GetComponent<TileChecker>().Structure = null;
    }
}
