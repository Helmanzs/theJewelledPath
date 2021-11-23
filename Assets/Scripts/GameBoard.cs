using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameBoard : MonoBehaviour
{
    public GameObject buildingSpot;
    public GameObject pathBuildingSpot;
    public Material pathMaterial;

    public GameObject basicEnemy;
    //-------------------------------------
    private int gridSize = 32;
    private GameObject[,] grid;
    //static List<GameObject> buildingSpots = new List<GameObject>();
    List<GameObject> enemies = new List<GameObject>();
    private float gameTileWidth = 0;
    private float gameTileHeight = 0;


    //TODO: odebrat collider u enemáků, nastavit delay spawnu

    void Awake()
    {
        //init grid
        grid = new GameObject[gridSize, gridSize];

        //set groud dimensions
        this.transform.localScale = new Vector3(2 * gridSize, 1, 2 * gridSize);
        this.transform.position = new Vector3(gridSize, 0, gridSize);

        //get dimensions of tile
        gameTileWidth = (this.transform.localScale.x / grid.GetLength(0));
        gameTileHeight = (this.transform.localScale.z / grid.GetLength(1));

        //set ground material tiling
        GetComponent<Renderer>().material.mainTextureScale = new Vector2(grid.GetLength(0), grid.GetLength(1));


    }

    void Start()
    {
        //create path blocks
        CreateTestPath();

        //generate building spots and grid
        GenerateGrid();

        FindObjectOfType<NavMeshSurface>().BuildNavMesh();

        //spawn enemies
        StartCoroutine(SpawnEnemies(10, basicEnemy));


    }


    void Update()
    {

    }

    IEnumerator SpawnEnemies(int number, GameObject type)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject enemy = Instantiate(type, new Vector3(Global.spawnTile.transform.position.x, 1, Global.spawnTile.transform.position.z), Quaternion.identity);
            enemies.Add(enemy);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void CreateTestPath()
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (i == 2 && j == 0)
                {
                    GameObject spawnTile = GeneratePathTile(i, j);
                    Global.spawnTile = spawnTile;
                    grid[i, j] = spawnTile;
                }
                if (i == 29 && j == 0)
                {
                    GameObject endTile = GeneratePathTile(i, j);
                    Global.endTile = endTile;
                    grid[i, j] = endTile;
                }
                if ((i == 2 && j <= 29) || (i == 29 && j <= 29))
                {
                    grid[i, j] = GeneratePathTile(i, j);
                }
                if (j == 29 && i >= 2 && i <= 29)
                {
                    grid[i, j] = GeneratePathTile(i, j);
                }
            }
        }
    }

    private GameObject GeneratePathTile(int i, int j)
    {
        GameObject pathSpot = Instantiate(pathBuildingSpot, new Vector3(i * gameTileWidth + gameTileWidth / 2, 0.51f, j * gameTileHeight + gameTileHeight / 2), Quaternion.identity);
        pathSpot.transform.localScale = new Vector3(gameTileWidth / 10, 0.01f, gameTileHeight / 10);
        pathSpot.GetComponent<Renderer>().material = pathMaterial;
        return pathSpot;
    }
    private void GenerateGrid()
    {
        GameObject spot;

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] == null)
                {
                    spot = Instantiate(buildingSpot, new Vector3(i * gameTileWidth + gameTileWidth / 2, 1, j * gameTileHeight + gameTileHeight / 2), Quaternion.identity);
                    spot.transform.localScale = new Vector3(gameTileWidth / 10, 0.01f, gameTileHeight / 10);
                    Global.buildingSpots.Add(spot);

                }
            }
        }
    }
}
