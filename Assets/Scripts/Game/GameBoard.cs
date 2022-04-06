using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameBoard : MonoBehaviour
{
    public GameObject buildingSpot;
    public GameObject pathBuildingSpot;
    public GameObject endSpot;
    public SpawnTile spawnSpot;
    public GameObject paths;
    public GameObject spots;

    public Texture2D level;

    private int white = 0;
    private int green = 0;
    private int red = 0;
    public void GenerateLevel(Texture2D level)
    {
        Color color;
        for (int i = 0; i < level.width; i++)
        {
            for (int j = 0; j < level.height; j++)
            {
                color = level.GetPixel(i, j);
                if (color == Color.black)
                    continue;

                print(ColorUtility.ToHtmlStringRGBA(color));

                if (color == Color.white)
                {
                    white++;
                }
                if (color == Color.red)
                {
                    red++;
                }
                if (color == Color.green)
                {
                    green++;
                }
            }
        }
        print($"white: {white}, red: {red}, green: {green}");
    }

    //-------------------------------------
    private int gridSize = 32;
    private GameObject[,] grid;
    private float gameTileWidth = 0;
    private float gameTileHeight = 0;

    void Awake()
    {
        //init grid
        grid = new GameObject[gridSize, gridSize];

        //set ground dimensions
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
        Time.timeScale = 1f;
        //create path blocks
        CreateTestPath();

        //generate building spots and grid
        GenerateGrid();

        FindObjectOfType<NavMeshSurface>().BuildNavMesh();

    }
    private void CreateTestPath()
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (i == 2 && j == 0)
                {
                    SpawnTile spawnTile = CreateSpawnTile(i, j);
                    Global.Instance.spawnTile = spawnTile;
                    grid[i, j] = spawnTile.gameObject;
                }
                if (i == 29 && j == 0)
                {
                    GameObject endTile = CreateEndTile(i, j);
                    Global.Instance.endTile = endTile;
                    grid[i, j] = endTile;
                }
                if ((i == 2 && j != 0 && j <= 29) || (i == 29 && j != 0 && j <= 29))
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
        pathSpot.transform.SetParent(paths.transform);

        return pathSpot;
    }

    private GameObject CreateEndTile(int i, int j)
    {
        GameObject endTile = Instantiate(endSpot, new Vector3(i * gameTileWidth + gameTileWidth / 2, 0.51f, j * gameTileHeight + gameTileHeight / 2), Quaternion.identity);
        endTile.transform.localScale = new Vector3(gameTileWidth / 10, 0.01f, gameTileHeight / 10);
        endTile.transform.SetParent(paths.transform);

        return endTile;
    }

    private SpawnTile CreateSpawnTile(int i, int j)
    {
        SpawnTile spawnTile = Instantiate(spawnSpot, new Vector3(i * gameTileWidth + gameTileWidth / 2, 0.51f, j * gameTileHeight + gameTileHeight / 2), Quaternion.identity);
        spawnTile.transform.localScale = new Vector3(gameTileWidth / 10, 0.01f, gameTileHeight / 10);
        spawnTile.transform.SetParent(paths.transform);

        return spawnTile;

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
                    spot = Instantiate(buildingSpot, new Vector3(i * gameTileWidth + gameTileWidth / 2, 0.51f, j * gameTileHeight + gameTileHeight / 2), Quaternion.identity);
                    spot.transform.localScale = new Vector3(gameTileWidth / 10, 0.01f, gameTileHeight / 10);
                    Global.Instance.buildingSpots.Add(spot);

                    spot.transform.SetParent(spots.transform);
                }
            }
        }
        int count = 0;
        foreach (GameObject tile in Global.Instance.buildingSpots)
        {

            if (tile.tag == "EmptyBuildingSpot")
            {
                tile.name = $"BuildingSpot-{count}";
            }
            count++;

        }
    }
}
