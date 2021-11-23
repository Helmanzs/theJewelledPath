using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManagement : MonoBehaviour
{
    //buildings
    public GameObject tower;

    //---------------------------

    private GameObject building;
    private GameObject previewedBuilding = null;
    private bool placingBuilding = false;
    private bool IsPreviewed = false;

    public bool CanPlaceBuilding
    {
        get { return building == null; }
    }

    void Update()
    {
        //place tower after place tower button has been pressed
        if (placingBuilding)
        {

            PreviewBuilding();
            if (Input.GetMouseButtonDown(0))
            {
                EnterBuildingMode();
            }
            else if (Input.GetMouseButton(1))
            {
                ExitBuildingMode();
            }
        }
    }


    //insert building on buildingSpot
    public void InsertBuilding(GameObject b)
    {
        building = Instantiate(b, this.transform.position, Quaternion.identity) as GameObject;
        building.transform.SetParent(this.transform);
        building.transform.position = new Vector3(this.transform.position.x, 2, this.transform.position.z);
    }

    public void DeleteBuilding()
    {
        this.tag = "EmptyBuildingSpot";
        Destroy(building);
        building = null;
    }

    public void AddTower()
    {
        //check if tower can be placed on some buildingSpot
        if (Global.buildingSpots.FindAll(t => t.GetComponent<BuildingManagement>().CanPlaceBuilding).Count == 0)
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
            GameObject currentSpot = getBuildingSpot();

            //check if spot is empty
            if (currentSpot.GetComponent<BuildingManagement>().CanPlaceBuilding)
            {
                if (currentSpot != Global.endTile)
                {
                    //place preview
                    currentSpot.GetComponent<BuildingManagement>().InsertBuilding(previewedBuilding.GetComponent<Building>().previewBuilding);
                    currentSpot.GetComponent<BuildingManagement>().IsPreviewed = true;

                    //delete preview from last spot
                    if (Global.endTile != null)
                    {
                        Global.endTile.GetComponent<BuildingManagement>().DeleteBuilding();
                        Global.endTile.GetComponent<BuildingManagement>().IsPreviewed = false;

                    }
                    Global.endTile = currentSpot;
                }
            }
        }

    }

    private void EnterBuildingMode()
    {
        if (getBuildingSpot() != null)
        {
            //get empty spot
            GameObject emptySpot = getBuildingSpot();
            if (emptySpot.GetComponent<BuildingManagement>().IsPreviewed)
            {
                //delete preview building
                emptySpot.GetComponent<BuildingManagement>().IsPreviewed = false;
                emptySpot.GetComponent<BuildingManagement>().DeleteBuilding();

                //place building
                if (emptySpot.GetComponent<BuildingManagement>().CanPlaceBuilding)
                {
                    emptySpot.GetComponent<BuildingManagement>().InsertBuilding(previewedBuilding);
                    emptySpot.transform.tag = "BuildingSpot";
                    placingBuilding = false;
                    previewedBuilding = null;
                    Global.endTile = null;
                }
            }

        }
    }

    private void ExitBuildingMode()
    {
        placingBuilding = false;
        previewedBuilding = null;
        if (Global.endTile != null)
        {
            Global.endTile.GetComponent<BuildingManagement>().DeleteBuilding();
            Global.endTile.GetComponent<BuildingManagement>().IsPreviewed = false;
        }
    }

    public GameObject getBuildingSpot()
    {
        //get buildingSpot on mouse click
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
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
