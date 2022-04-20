using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatisticsData : SceneSingleton<GameStatisticsData>
{
    public bool dirty = false;

    //enemies
    private int killedEnemies = 0;
    private int killedNormals = 0;
    private int killedTanks = 0;
    private int killedFasts = 0;
    private int killedBosses = 0;

    //buildings
    private int placedBuildings = 0;
    private int placedTowers = 0;
    private int placedAmplifiers = 0;
    private int placedTraps = 0;
    private int placedLanterns = 0;

    //gems
    private int gemsInserted = 0;
    private int fireGemsInserted = 0;
    private int iceGemsInserted = 0;
    private int poisonGemsInserted = 0;
    private int lightningGemsInserted = 0;
    private int manaGemsInserted = 0;
    private int critGemsInserted = 0;

    public int PlacedBuildings
    {
        get => placedBuildings;
        set
        {
            placedBuildings = value;
            dirty = true;
        }
    }
    public int KilledEnemies
    {
        get => killedEnemies;
        set
        {
            killedEnemies = value;
            dirty = true;
        }
    }

    public int PlacedTowers
    {
        get => placedTowers;
        private set
        {
            placedTowers = value;
            dirty = true;
        }
    }
    public int PlacedAmplifiers
    {
        get => placedAmplifiers;
        private set
        {
            placedAmplifiers = value;
            dirty = true;
        }
    }
    public int PlacedTraps
    {
        get => placedTraps;
        private set
        {
            placedTraps = value;
            dirty = true;
        }
    }
    public int PlacedLanterns
    {
        get => placedLanterns;
        private set
        {
            placedLanterns = value;
            dirty = true;
        }
    }

    public int KilledNormals
    {
        get => killedNormals;
        private set
        {
            killedNormals = value;
            dirty = true;
        }
    }
    public int KilledTanks
    {
        get => killedTanks;
        private set
        {
            killedTanks = value;
            dirty = true;
        }
    }
    public int KilledFasts
    {
        get => killedFasts;
        private set
        {
            killedFasts = value;
            dirty = true;
        }
    }
    public int KilledBosses
    {
        get => killedBosses;
        private set
        {
            killedBosses = value;
            dirty = true;
        }
    }

    public int GemsInserted
    {
        get => gemsInserted;
        private set
        {
            gemsInserted = value;
            dirty = true;
        }
    }
    public int FireGemsInserted
    {
        get => fireGemsInserted;
        private set
        {
            fireGemsInserted = value;
            dirty = true;
        }
    }
    public int IceGemsInserted
    {
        get => iceGemsInserted;
        private set
        {
            iceGemsInserted = value;
            dirty = true;
        }
    }
    public int PoisonGemsInserted
    {
        get => poisonGemsInserted;
        private set
        {
            poisonGemsInserted = value;
            dirty = true;
        }
    }
    public int LightningGemsInserted
    {
        get => lightningGemsInserted;
        private set
        {
            lightningGemsInserted = value;
            dirty = true;
        }
    }
    public int ManaGemsInserted
    {
        get => manaGemsInserted;
        private set
        {
            manaGemsInserted = value;
            dirty = true;
        }
    }
    public int CritGemsInserted
    {
        get => critGemsInserted;
        private set
        {
            critGemsInserted = value;
            dirty = true;
        }
    }

    public void AddStructure(Structure building)
    {
        placedBuildings++;
        if (building is Tower)
            PlacedTowers++;
        if (building is Amplifier)
            PlacedAmplifiers++;
        if (building is Trap)
            PlacedTraps++;
        if (building is Lantern)
            PlacedLanterns++;
    }

    public void AddEnemy(Enemy enemy)
    {
        killedEnemies++;
        if (enemy is BasicEnemy)
            KilledNormals++;
        if (enemy is FastEnemy)
            KilledFasts++;
        if (enemy is TankEnemy)
            KilledTanks++;
        if (enemy is Boss)
            KilledBosses++;
    }

    public void AddGem(Gem gem)
    {
        gemsInserted++;
        if (gem is FireGem)
            fireGemsInserted++;
        if (gem is IceGem)
            iceGemsInserted++;
        if (gem is PoisonGem)
            poisonGemsInserted++;
        if (gem is LightningGem)
            lightningGemsInserted++;
        if (gem is ManaGem)
            manaGemsInserted++;
        if (gem is CritGem)
            critGemsInserted++;
    }

    public void ClearGameStatistics()
    {
        PlacedBuildings = 0;
        PlacedTowers = 0;
        PlacedAmplifiers = 0;
        PlacedLanterns = 0;
        PlacedTraps = 0;

        KilledEnemies = 0;
        KilledNormals = 0;
        KilledFasts = 0;
        KilledTanks = 0;
        KilledBosses = 0;

        GemsInserted = 0;
        FireGemsInserted = 0;
        IceGemsInserted = 0;
        PoisonGemsInserted = 0;
        LightningGemsInserted = 0;
        ManaGemsInserted = 0;
        CritGemsInserted = 0;
    }
}
