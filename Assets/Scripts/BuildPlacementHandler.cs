using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlacementHandler : MonoBehaviour
{
    public Camera myCamera;

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
