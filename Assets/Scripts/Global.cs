using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    public static List<GameObject> buildingSpots = new List<GameObject>();
    public static List<Structure> buildings = new List<Structure>();
    public static List<GameObject> enemies = new List<GameObject>();

    public static int lives = 100;

    public static int mana = 0;
    public static int Mana
    {
        get { return mana; }
        set
        {
            mana = value;
            if (mana <= 0)
            {
                mana = 0;
            }
        }
    }

    public static GameObject endTile = null;
    public static GameObject spawnTile = null;
}