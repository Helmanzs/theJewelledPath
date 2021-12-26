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
                PreviewedUnit = null;
            }
            else if (Input.GetMouseButton(1))
            {
                if (lastPlace != null)
                {
                    DeleteShowcasedGem(lastPlace);
                }

                PreviewedUnit = null;
            }
        }
    }

    public void AddGem(Gem gem)
    {
        if (gem == null)
        {
            return;
        }

        PreviewedUnit = GameObject.Instantiate(gem, new Vector3(0, 0, 0), Quaternion.identity);
        PreviewedUnit.gameObject.SetActive(false);
        gemBuildingMode = true;
    }

    protected override void PreviewUnit()
    {
        if (Global.buildings.FindAll(building => building.GetComponent<GemBuilding>()).Count == 0)
        {
            PreviewedUnit = null;
            return;
        }

        if (selector.GetObject(1 << 8, "EmptyTower") != null)
        {
            T previewedSpot = selector.GetObject(1 << 8, "EmptyTower");
            Transform spot = previewedSpot as Transform;
            if (spot != lastPlace)
            {
                ShowcaseGem(spot.gameObject);
                if (lastPlace != null)
                {
                    DeleteShowcasedGem(lastPlace);
                    Debug.Log(lastPlace.transform.parent);
                }
                lastPlace = previewedSpot;
            }

        }
    }



    protected override void AddUnit(T place)
    {
        place.GetComponent<GemBuilding>().InsertGem(PreviewedUnit as Gem);
    }

    private void ShowcaseGem(GameObject place)
    {
        place.GetComponent<GemBuilding>().ShowcasedGem = PreviewedUnit as Gem;
        PreviewedUnit.transform.SetParent(place.transform);
        PreviewedUnit.gameObject.SetActive(true);
    }

    private void DeleteShowcasedGem(T place)
    {
        GemBuilding structure = place as GemBuilding;
        if (place.GetComponent<GemBuilding>().ShowcasedGem == null)
        {
            return;
        }
        place.GetComponent<GemBuilding>().ShowcasedGem = null;
    }

    protected override void DeleteUnit(GameObject place, GameObject unit)
    {

    }
}
