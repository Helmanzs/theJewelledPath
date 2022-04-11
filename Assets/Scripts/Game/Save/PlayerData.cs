using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string saveName;
    public int currency;
    public int clearedLevels;

    public PlayerData(Player player)
    {
        this.saveName = player.saveName;
        this.currency = player.currency;
        this.clearedLevels = player.clearedLevels;
    }
}
