using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string saveName;
    public int exp;
    public int[] clearedLevels;

    public PlayerData(Player player)
    {
        this.saveName = player.saveName;
        this.exp = player.exp;
        this.clearedLevels = player.clearedLevels.ToArray();
    }
}
