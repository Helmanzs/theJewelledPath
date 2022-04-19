using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

public class Player : GameSingleton<Player>
{
    public string saveName = "";
    public int clearedLevels = 0;

    public void Clear()
    {
        saveName = "";
        clearedLevels = 0;
    }

    public void Load(PlayerData data)
    {
        this.saveName = data.saveName;
        this.clearedLevels = data.clearedLevels;
    }
}
