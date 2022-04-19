using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string saveName;
    public int clearedLevels;

    public PlayerData(Player player)
    {
        this.saveName = player.saveName;
        this.clearedLevels = player.clearedLevels;
    }
}
