using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    private GameObject placedBuilding;
    private bool isPreviewed = false;


    public bool CanPlaceBuilding
    {
        get { return placedBuilding == null; }
    }

    public bool IsPreviewed
    {
        get { return placedBuilding == null; }
        set { isPreviewed = value; }
    }

    public GameObject GetPlacedBuilding
    {
        get { return placedBuilding; }
    }

    //insert placedBuilding on buildingSpot
    public void InsertBuilding(GameObject b)
    {
        placedBuilding = Instantiate(b, this.transform.position, Quaternion.identity) as GameObject;
        Global.buildings.Add(placedBuilding);
        placedBuilding.transform.SetParent(this.transform);
        placedBuilding.transform.position = new Vector3(this.transform.position.x, 2, this.transform.position.z);
    }

    public void DeleteBuilding(GameObject b)
    {
        this.tag = "EmptyBuildingSpot";
        Global.buildings.Remove(b);
        Destroy(placedBuilding);
        placedBuilding = null;
    }
}
