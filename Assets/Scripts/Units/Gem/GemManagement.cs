using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemManagement<T> : BuildingManagement<T> where T : Component
{
    public void Update()
    {
        if (gemBuildingMode)
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

    public void AddGem(Gem gem)
    {
        Unit = GameObject.Instantiate(gem, new Vector3(0, 0, 0), Quaternion.identity);
        Unit.gameObject.SetActive(false);
        UnitPreview = GameObject.Instantiate(((Gem)Unit).previewUnit, new Vector3(0, 0, 0), Quaternion.identity);
        UnitPreview.gameObject.SetActive(false);
        gemBuildingMode = true;
    }

    protected override void PreviewUnit()
    {
        if (Global.buildings.FindAll(building => building.GetComponent<GemBuilding>()).Count == 0)
        {
            Unit = null;
            return;
        }

        if (selector.GetObject(1 << 8, "EmptyTower") != null)
        {
            T previewedSpot = selector.GetObject(1 << 8, "EmptyTower");
            GemBuilding spot = previewedSpot as GemBuilding;

            if (spot != lastPlace)
            {
                ShowcaseUnit(spot as T);
                lastPlace = previewedSpot;
            }

        }
    }

    protected override void AddUnit(T place)
    {
        GemBuilding structure = place as GemBuilding;
        if (structure.ShowcasedGem == null)
        {
            Unit.gameObject.SetActive(true);
        }
        structure.InsertGem(Unit as Gem);
        Unit.transform.SetParent(structure.transform);
        GameObject.Destroy(UnitPreview.gameObject);
        Unit = null;

    }
    protected override void DeleteUnit(T place, T unit)
    {

    }

    protected override void ShowcaseUnit(T place)
    {
        GemBuilding spot = place as GemBuilding;
        UnitPreview.gameObject.SetActive(true);
        UnitPreview.transform.SetParent(spot.transform);
        UnitPreview.transform.localPosition = new Vector3(0, 0, 0);
    }





}
