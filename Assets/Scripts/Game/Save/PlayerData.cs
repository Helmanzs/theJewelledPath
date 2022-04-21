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

    //enemies
    public int killedEnemies = 0;
    public int killedNormals = 0;
    public int killedTanks = 0;
    public int killedFasts = 0;
    public int killedBosses = 0;

    //buildings
    public int placedBuildings = 0;
    public int placedTowers = 0;
    public int placedAmplifiers = 0;
    public int placedTraps = 0;
    public int placedLanterns = 0;

    //gems
    public int gemsInserted = 0;
    public int fireGemsInserted = 0;
    public int iceGemsInserted = 0;
    public int poisonGemsInserted = 0;
    public int lightningGemsInserted = 0;
    public int manaGemsInserted = 0;
    public int critGemsInserted = 0;

    public PlayerData(Player player)
    {
        this.saveName = player.saveName;
        this.clearedLevels = player.ClearedLevels;

        this.killedTanks = player.killedTanks;
        this.killedEnemies = player.killedEnemies;
        this.killedNormals = player.killedNormals;
        this.killedFasts = player.killedFasts;
        this.killedBosses = player.killedBosses;

        this.placedLanterns = player.placedLanterns;
        this.placedBuildings = player.placedBuildings;
        this.placedTowers = player.placedTowers;
        this.placedTraps = player.placedTraps;
        this.placedAmplifiers = player.placedAmplifiers;

        this.gemsInserted = player.gemsInserted;
        this.iceGemsInserted = player.iceGemsInserted;
        this.fireGemsInserted = player.fireGemsInserted;
        this.poisonGemsInserted = player.poisonGemsInserted;
        this.lightningGemsInserted = player.lightningGemsInserted;
        this.manaGemsInserted = player.manaGemsInserted;
        this.critGemsInserted = player.critGemsInserted;
    }
}
