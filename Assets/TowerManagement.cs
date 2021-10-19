using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManagement : MonoBehaviour
{
    private GameObject tower;

    public bool CanPlace{
        get { return tower == null; }
    }
    public void InsertTower(GameObject t){
        tower = Instantiate(t, this.transform.position, Quaternion.identity) as GameObject;
        tower.transform.SetParent(this.transform);
        tower.transform.position = new Vector3(this.transform.position.x, 2, this.transform.position.z);
    }
}
