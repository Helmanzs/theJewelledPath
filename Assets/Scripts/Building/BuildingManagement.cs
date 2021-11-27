using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManagement : MonoBehaviour
{
    //buildings
    public GameObject tower;

    //---------------------------

    private GameObject previewedBuilding = null;
    private bool placingBuilding = false;
    private GameObject lastSpot;

    private int layerMask = 1 << 7;

    void Update()
    {
        //place tower after place tower button has been pressed
        if (placingBuilding)
        {
            PreviewBuilding();
            if (Input.GetMouseButtonDown(0))
            {
                PlaceBuilding();
            }
            else if (Input.GetMouseButton(1))
            {
                ExitBuildingMode();
            }
        }
    }

    public void AddTower()
    {
        //check if tower can be placed on some buildingSpot
        if (Global.buildingSpots.FindAll(buildingSpot => buildingSpot.GetComponent<BuildingManager>().CanPlaceBuilding).Count == 0)
        {
            return;
        }
        previewedBuilding = tower;
        placingBuilding = true;
    }

    private void PreviewBuilding()
    {
        //check if user clicked on spot
        if (getBuildingSpot() != null)
        {
            GameObject previewedSpot = getBuildingSpot();

            //check if spot is empty
            if (previewedSpot.GetComponent<BuildingManager>().CanPlaceBuilding)
            {
                if (previewedSpot != lastSpot)
                {
                    //place preview
                    previewedSpot.GetComponent<BuildingManager>().InsertBuilding(previewedBuilding.GetComponent<Building>().previewBuilding);
                    previewedSpot.GetComponent<BuildingManager>().IsPreviewed = true;

                    //delete preview from last spot
                    if (lastSpot != null)
                    {
                        lastSpot.GetComponent<BuildingManager>().DeleteBuilding(lastSpot.GetComponent<BuildingManager>().GetPlacedBuilding);
                        lastSpot.GetComponent<BuildingManager>().IsPreviewed = false;

                    }
                    lastSpot = previewedSpot;
                }
            }
        }
    }

    private void PlaceBuilding()
    {
        if (lastSpot == null)
        {
            return;
        }
        //delete preview building
        lastSpot.GetComponent<BuildingManager>().IsPreviewed = false;
        lastSpot.GetComponent<BuildingManager>().DeleteBuilding(lastSpot.GetComponent<BuildingManager>().GetPlacedBuilding);
        //place building

        lastSpot.GetComponent<BuildingManager>().InsertBuilding(previewedBuilding);
        lastSpot.transform.tag = "BuildingSpot";
        placingBuilding = false;
        previewedBuilding = null;
        lastSpot = null;
    }

    private void ExitBuildingMode()
    {
        placingBuilding = false;
        previewedBuilding = null;
        if (lastSpot != null)
        {
            lastSpot.GetComponent<BuildingManager>().DeleteBuilding(lastSpot.GetComponent<BuildingManager>().GetPlacedBuilding);
            lastSpot.GetComponent<BuildingManager>().IsPreviewed = false;
        }
    }
    public GameObject getBuildingSpot()
    {
        //get buildingSpot on mouse click
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, float.PositiveInfinity, layerMask);
        if (hit)
        {
            if (hitInfo.transform.gameObject.tag == "EmptyBuildingSpot")
            {
                return hitInfo.transform.gameObject;
            }
            else
            {
                return null;
            }
        }
        return null;
    }
}
