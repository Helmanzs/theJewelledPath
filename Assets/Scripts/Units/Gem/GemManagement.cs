using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GemManagement<T> : BuildingManagement<T> where T : Component
{
    public void AddGem(Gem gem)
    {
        if (Global.Instance.Mana - (int)gem.cost >= 0 && Global.Instance.gemBuildings.Count != 0)
        {
            if (Unit != null)
            {
                DeleteShowcasedUnit();
            }
            Unit = GameObject.Instantiate(gem, new Vector3(0, 0, 0), Quaternion.identity);
            Unit.gameObject.SetActive(false);
            UnitPreview = GameObject.Instantiate(((Gem)Unit).previewUnit, new Vector3(0, 0, 0), Quaternion.identity);
            UnitPreview.gameObject.SetActive(false);
            buildingMode = true;
        }
    }

    protected override void PreviewUnit()
    {
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
        if (place != default(T))
        {
            GemBuilding gemBuilding = place as GemBuilding;
            Gem gem = Unit as Gem;
            gemBuilding.EnableGem();
            gemBuilding.InsertGem(gem);
            Global.Instance.Mana -= (int)gem.cost;
            GameObject.Destroy(Unit.gameObject);
            GameObject.Destroy(UnitPreview.gameObject);
            Unit = null;
            buildingMode = false;
        }
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
