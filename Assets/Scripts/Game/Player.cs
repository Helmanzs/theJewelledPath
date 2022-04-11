using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : GameSingleton<Player>
{
    public string saveName = "";
    public int currency = 0;
    public int clearedLevels = 0;

    public void Clear()
    {
        saveName = "";
        currency = 0;
        clearedLevels = 0;
    }

    public void Load(PlayerData data)
    {
        this.saveName = data.saveName;
        this.currency = data.currency;
        this.clearedLevels = data.clearedLevels;
    }
}
