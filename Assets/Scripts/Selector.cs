using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector<T>
{
    // public GameObject selectionCircle;

    public T GetObject(LayerMask layerMask, string tag)
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, float.PositiveInfinity, layerMask);
        if (hit)
        {
            if (hitInfo.transform.gameObject.tag == tag)
            {
                return hitInfo.transform.GetComponent<T>();
            }
            else
            {
                return default(T);
            }
        }
        return default(T);
    }

}
