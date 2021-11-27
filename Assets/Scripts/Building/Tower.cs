using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Building
{
    private GameObject placedGem;
    private bool isPreviewed;

    public bool CanPlaceGem
    {
        get { return placedGem == null; }
    }

    public GameObject GetPlacedGem
    {
        get { return placedGem; }
    }

    public bool IsPreviewed
    {
        get { return placedGem == null; }
        set { isPreviewed = value; }
    }

    public void InsertGem(GameObject g)
    {
        placedGem = Instantiate(g, this.transform.position, Quaternion.identity) as GameObject;
        Global.gems.Add(g);
        placedGem.transform.SetParent(this.transform);
        placedGem.transform.position = new Vector3(this.transform.position.x, 5, this.transform.position.z);
    }

    public void DeleteGem(GameObject g)
    {
        this.tag = "EmptyTower";
        Global.gems.Remove(g);
        Destroy(placedGem);
        placedGem = null;
    }

}
