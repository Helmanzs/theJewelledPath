using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameSingleton<Player>
{
    public string saveName = "";
    public int exp = 0;
    public List<int> clearedLevels = new List<int>();
}
