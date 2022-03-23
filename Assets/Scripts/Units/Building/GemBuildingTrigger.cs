using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBuildingTrigger : MonoBehaviour
{
    private GemBuilding gemBuilding;
    private void Awake()
    {
        gemBuilding = GetComponentInParent<GemBuilding>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //gemBuilding.AddTarget(other.GetComponent<Enemy>());
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            //gemBuilding.RemoveTarget(other.GetComponent<Enemy>());
        }
    }
}
