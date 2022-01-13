using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : SceneSingleton<Global>
{
    public List<GameObject> buildingSpots = new List<GameObject>();
    public List<Structure> buildings = new List<Structure>();
    public List<GemBuilding> gemBuildings = new List<GemBuilding>();
    public List<Enemy> enemies = new List<Enemy>();

    private int mana = 300;
    public int Mana
    {
        get { return mana; }
        set
        {
            mana = value;
        }
    }

    public GameObject endTile = null;
    public SpawnTile spawnTile = null;

}