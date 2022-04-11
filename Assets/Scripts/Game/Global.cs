using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : SceneSingleton<Global>
{
    public List<BuildingSpot> buildingSpots = new List<BuildingSpot>();
    public List<Structure> buildings = new List<Structure>();
    public List<GemBuilding> gemBuildings = new List<GemBuilding>();
    public List<Enemy> enemies = new List<Enemy>();

    private int mana = 30000;
    public int Mana
    {
        get { return mana; }
        set
        {
            mana = value;
        }
    }

    public EndTile endTile = null;
    public SpawnTile spawnTile = null;
}