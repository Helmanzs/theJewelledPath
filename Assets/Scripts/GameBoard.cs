using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public GameObject buildingSpot;
    public GameObject pathBuildingSpot;
    public GameObject tower;
    public Material pathMaterial;
    //-------------------------------------
    private int gridSize = 32;
    private GameObject[,] grid;
    List<GameObject> buildingSpots = new List<GameObject>();
    private float gameTileWidth = 0;
    private float gameTileHeight = 0;

    private bool placingBuilding = false;
    private GameObject previewedBuilding = null;

    private GameObject lastSpot = null;


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

        //generate building spots on grid
        GenerateGrid();
    }


    void Update()
    {
        //place tower after place tower button has been pressed
        if (placingBuilding)
        {

            PreviewBuilding();
            if (Input.GetMouseButtonDown(0))
            {
                EnterBuildingMode();
            }
            else if (Input.GetMouseButton(1))
            {
                ExitBuildingMode();
            }
        }
    }



    public void AddTower()
    {
        //check if tower can be placed on buildingSpot
        if (buildingSpots.FindAll(t => t.GetComponent<BuildingManagement>().CanPlaceBuilding).Count == 0)
        {
            return;
        }
        previewedBuilding = tower;
        placingBuilding = true;

    }

    private void PreviewBuilding()
    {
        //check if user clicked on spot
        if (this.gameObject.GetComponent<BuildPlacementHandler>().getBuildingSpot() != null)
        {
            GameObject currentSpot = this.gameObject.GetComponent<BuildPlacementHandler>().getBuildingSpot();

            //check if spot is empty
            if (currentSpot.GetComponent<BuildingManagement>().CanPlaceBuilding)
            {
                if (currentSpot != lastSpot)
                {
                    //place preview
                    currentSpot.GetComponent<BuildingManagement>().InsertBuilding(previewedBuilding.GetComponent<Building>().previewTower);
                    currentSpot.GetComponent<BuildingManagement>().IsPreviewed = true;

                    //delete preview from last spot
                    if (lastSpot != null)
                    {
                        lastSpot.GetComponent<BuildingManagement>().DeleteBuilding();
                        lastSpot.GetComponent<BuildingManagement>().IsPreviewed = false;

                    }
                    lastSpot = currentSpot;
                }
            }
        }

    }

    private void EnterBuildingMode()
    {
        if (this.gameObject.GetComponent<BuildPlacementHandler>().getBuildingSpot() != null)
        {
            //get empty spot
            GameObject emptySpot = this.gameObject.GetComponent<BuildPlacementHandler>().getBuildingSpot();
            if (emptySpot.GetComponent<BuildingManagement>().IsPreviewed)
            {
                //delete preview building
                emptySpot.GetComponent<BuildingManagement>().IsPreviewed = false;
                emptySpot.GetComponent<BuildingManagement>().DeleteBuilding();

                //place building
                if (emptySpot.GetComponent<BuildingManagement>().CanPlaceBuilding)
                {
                    emptySpot.GetComponent<BuildingManagement>().InsertBuilding(previewedBuilding);
                    emptySpot.transform.tag = "BuildingSpot";
                    placingBuilding = false;
                    previewedBuilding = null;
                    lastSpot = null;
                }
            }

        }
    }

    private void ExitBuildingMode()
    {
        placingBuilding = false;
        previewedBuilding = null;
        if (lastSpot != null)
        {
            lastSpot.GetComponent<BuildingManagement>().DeleteBuilding();
            lastSpot.GetComponent<BuildingManagement>().IsPreviewed = false;
        }
    }

    private void CreateTestPath()
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (i == 29 && j == 0)
                {
                    GameObject endTile = GeneratePathTile(i, j);
                    endTile.AddComponent<EndTile>();
                    endTile.GetComponent<EndTile>().endTile = endTile.transform;
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
                    buildingSpots.Add(spot);
                }
            }
        }
    }
}
