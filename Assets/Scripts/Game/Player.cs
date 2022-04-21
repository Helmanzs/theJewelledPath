using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

public class Player : GameSingleton<Player>
{
    public string saveName = "";
    [SerializeField] private int clearedLevels = 0;
    public string statisticsName = "";
    public string fileName = "";

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

    public int ClearedLevels
    {
        get => clearedLevels; set
        {
            clearedLevels = value;
            if (clearedLevels > 9)
            {
                clearedLevels = 9;
            }
        }
    }

    public void SumStatistics()
    {
        this.killedTanks += GameStatisticsData.Instance.KilledTanks;
        this.killedEnemies += GameStatisticsData.Instance.KilledEnemies;
        this.killedNormals += GameStatisticsData.Instance.KilledNormals;
        this.killedFasts += GameStatisticsData.Instance.KilledFasts;
        this.killedBosses += GameStatisticsData.Instance.KilledBosses;

        this.placedLanterns += GameStatisticsData.Instance.PlacedLanterns;
        this.placedBuildings += GameStatisticsData.Instance.PlacedBuildings;
        this.placedTowers += GameStatisticsData.Instance.PlacedTowers;
        this.placedTraps += GameStatisticsData.Instance.PlacedTraps;
        this.placedAmplifiers += GameStatisticsData.Instance.PlacedAmplifiers;

        this.gemsInserted += GameStatisticsData.Instance.GemsInserted;
        this.iceGemsInserted += GameStatisticsData.Instance.IceGemsInserted;
        this.fireGemsInserted += GameStatisticsData.Instance.FireGemsInserted;
        this.poisonGemsInserted += GameStatisticsData.Instance.PoisonGemsInserted;
        this.lightningGemsInserted += GameStatisticsData.Instance.LightningGemsInserted;
        this.manaGemsInserted += GameStatisticsData.Instance.ManaGemsInserted;
        this.critGemsInserted += GameStatisticsData.Instance.CritGemsInserted;
    }


    public void Clear()
    {
        saveName = "";
        ClearedLevels = 0;

        killedBosses = 0;
        killedTanks = 0;
        killedFasts = 0;
        killedNormals = 0;
        killedEnemies = 0;

        placedBuildings = 0;
        placedTowers = 0;
        placedTraps = 0;
        placedLanterns = 0;
        placedAmplifiers = 0;

        gemsInserted = 0;
        fireGemsInserted = 0;
        iceGemsInserted = 0;
        poisonGemsInserted = 0;
        lightningGemsInserted = 0;
        manaGemsInserted = 0;
        critGemsInserted = 0;
    }
    public void Load(PlayerData data)
    {
        this.saveName = data.saveName;
        this.ClearedLevels = data.clearedLevels;

        this.killedTanks = data.killedTanks;
        this.killedEnemies = data.killedEnemies;
        this.killedNormals = data.killedNormals;
        this.killedFasts = data.killedFasts;
        this.killedBosses = data.killedBosses;

        this.placedLanterns = data.placedLanterns;
        this.placedBuildings = data.placedBuildings;
        this.placedTowers = data.placedTowers;
        this.placedTraps = data.placedTraps;
        this.placedAmplifiers = data.placedAmplifiers;

        this.gemsInserted = data.gemsInserted;
        this.iceGemsInserted = data.iceGemsInserted;
        this.fireGemsInserted = data.fireGemsInserted;
        this.poisonGemsInserted = data.poisonGemsInserted;
        this.lightningGemsInserted = data.lightningGemsInserted;
        this.manaGemsInserted = data.manaGemsInserted;
        this.critGemsInserted = data.critGemsInserted;
    }
}
