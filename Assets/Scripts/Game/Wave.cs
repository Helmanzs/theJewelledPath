using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wave : ScriptableObject
{
    private Enemy enemyType1;
    private Enemy enemyType2;
    private int count1;
    private int count2;
    private int countdown = 30;
    private SpawnTile spawnTile1;
    private SpawnTile spawnTile2;

    public Enemy EnemyType1 { get => enemyType1; set => enemyType1 = value; }
    public Enemy EnemyType2 { get => enemyType2; set => enemyType2 = value; }
    public int Count1 { get => count1; set => count1 = value; }
    public int Count2 { get => count2; set => count2 = value; }
    public int Countdown { get => countdown; set => countdown = value; }
    public SpawnTile SpawnTile1 { get => spawnTile1; set => spawnTile1 = value; }
    public SpawnTile SpawnTile2 { get => spawnTile2; set => spawnTile2 = value; }
}
