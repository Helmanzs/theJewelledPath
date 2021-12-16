using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    public static List<GameObject> buildingSpots = new List<GameObject>();
    public static List<GameObject> buildings = new List<GameObject>();
    public static List<GameObject> gems = new List<GameObject>();

    public static int lives = 100;

    public static int mana = 0;
    public static int Mana
    {
        get { return mana; }
        set
        {
            if (mana - value <= 0)
            {
                mana = 0;
            }
            else
            {
                mana -= value;
            }
        }
    }

    public static GameObject endTile = null;
    public static GameObject spawnTile = null;


}