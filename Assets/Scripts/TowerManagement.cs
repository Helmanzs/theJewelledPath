using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManagement : MonoBehaviour
{
    private GameObject building;

    public bool CanPlaceBuilding
    {
        get { return building == null; }
    }

    //insert tower on tower spot
    public void InsertBuilding(GameObject b)
    {
        building = Instantiate(b, this.transform.position, Quaternion.identity) as GameObject;
        building.transform.SetParent(this.transform);
        building.transform.position = new Vector3(this.transform.position.x, 2, this.transform.position.z);
    }
}
