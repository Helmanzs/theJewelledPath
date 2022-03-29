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
        if (other.TryGetComponent(out Enemy enemy))
        {
            gemBuilding.AddTarget(enemy);
        }
        if (other.TryGetComponent(out Structure structure))
        {
            gemBuilding.AddTarget(structure);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            gemBuilding.RemoveTarget(enemy);
        }
        if (other.TryGetComponent(out Structure structure))
        {
            gemBuilding.RemoveTarget(structure);
        }
    }
}
