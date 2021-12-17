using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemManagement : MonoBehaviour
{
    public GameObject waterGem;

    private GameObject lastTower;

    private bool placingGem = false;


    private void Update()
    {
        //place gem after place gem button has been pressed
        if (placingGem)
        {
            //PreviewGem();
            if (Input.GetMouseButtonDown(0))
            {
              //  PlaceGem();
            }
            else if (Input.GetMouseButton(1))
            {
                //ExitBuildingMode();
            }
        }
    }
    /*public void CreateGem()
    {
        //check if tower can be placed on some buildingSpot
        if (Global.buildings.FindAll(building => building.GetComponent<GemBuilding>()).Count == 0)
        {
            return;
        }
        placingGem = true;
    }

    private void PreviewGem()
    {
        //check if user clicked on spot
        if (Global.buildings.Count == 0)
        {
            return;
        }

        if (GetTower() != null)
        {
            GameObject previewedTower = GetTower();

            //check if spot is empty
                if (previewedTower != lastTower)
                {
                    //place preview
                    previewedTower.GetComponent<Tower>().InsertGem(waterGem);
                    //previewedTower.GetComponent<Tower>().IsPreviewed = true;

                    //delete preview from last spot
                    if (lastTower != null)
                    {
                       // lastTower.GetComponent<Tower>().DeleteGem(lastTower.GetComponent<Tower>().GetPlacedGem);
                        //lastTower.GetComponent<BuildingManager>().IsPreviewed = false;

                    }
                    lastTower = previewedTower;
               }
        }
    }

    private void PlaceGem()
    {
        if (lastTower == null)
        {
            return;
        }
        //delete preview building
        lastTower.GetComponent<Tower>().IsPreviewed = false;
        lastTower.GetComponent<Tower>().DeleteGem(lastTower.GetComponent<Tower>().GetPlacedGem);
        //place building

        lastTower.GetComponent<Tower>().InsertGem(waterGem);
        lastTower.transform.tag = "Tower";
        placingGem = false;
        lastTower = null;
    }

    private void ExitBuildingMode()
    {
        placingGem = false;

        if (lastTower != null)
        {
            lastTower.GetComponent<Tower>().DeleteGem(lastTower.GetComponent<Tower>().GetPlacedGem);
            lastTower.GetComponent<Tower>().IsPreviewed = false;
        }
    }


    public GameObject GetTower()
    {
        //get tower on mouse click
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, float.PositiveInfinity, 1 << 8);
        if (hit)
        {
            if (hitInfo.transform.gameObject.tag == "EmptyTower")
            {
                return hitInfo.transform.gameObject;
            }
            else
            {
                return null;
            }
        }
        return null;
    }*/
}
