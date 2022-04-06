using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : GameSingleton<Player>
{
    public string saveName = "";
    public int exp = 0;
    public List<int> clearedLevels = new List<int>();

    public void Clear()
    {
        saveName = "";
        exp = 0;
        clearedLevels.Clear();
    }

    public void Load(PlayerData data)
    {
        this.saveName = data.saveName;
        this.exp = data.exp;
        this.clearedLevels = data.clearedLevels.ToList();
    }
}
