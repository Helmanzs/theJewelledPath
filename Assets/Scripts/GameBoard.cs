using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public GameObject buildingSpot;
    public GameObject tower;
    public int gridSize = 32;
    //-------------------------------------
    private int[,] grid;
    List<GameObject> buildingSpots = new List<GameObject>();
    private float gameTileWidth = 0;
    private float gameTileHeight = 0;

    private bool placingBuilding = false;
    private GameObject previewedBuilding = null;


    private void Awake()
    {
        //init grid
        grid = new int[gridSize, gridSize];

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

        //generate building spots on grid
        GameObject spot;

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                spot = Instantiate(buildingSpot, new Vector3(i * gameTileWidth + gameTileWidth / 2, 0, j * gameTileHeight + gameTileHeight / 2), Quaternion.identity);
                spot.transform.localScale = new Vector3(gameTileWidth / 10, 0.01f, gameTileHeight / 10);
                buildingSpots.Add(spot);
            }
        }
    }


    void Update()
    {
        //place tower after place tower button has been pressed
        if (placingBuilding)
        {

            PreviewBuilding();
            if (Input.GetMouseButtonDown(0))
            {
                PlaceBuilding();
            }
            else if (Input.GetMouseButton(1))
            {
                placingBuilding = false;
                previewedBuilding = null;
            }
        }
    }



    public void AddTower()
    {
        //check if tower can be placed on buildingSpot
        if (buildingSpots.FindAll(t => t.GetComponent<BuildingManagement>().CanPlaceBuilding).Count == 0)
        {
            Debug.Log("No empty tile left.");
            return;
        }
        previewedBuilding = tower;
        placingBuilding = true;

        //TODO: make it on player mouse movement
    }

    private void PreviewBuilding()
    {
        if (this.gameObject.GetComponent<BuildPlacementHandler>().getBuildingSpot() != null)
        {
            GameObject emptySpot = this.gameObject.GetComponent<BuildPlacementHandler>().getBuildingSpot();
            if (emptySpot.GetComponent<BuildingManagement>().CanPlaceBuilding)
            {
                Color tempColor = previewedBuilding.GetComponent<Renderer>().material.color;
                tempColor.a = 0.5f;
                previewedBuilding.GetComponent<Renderer>().material.color = tempColor;

                emptySpot.GetComponent<BuildingManagement>().InsertBuilding(previewedBuilding);
            }
        }

    }

    public void PlaceBuilding()
    {
        if (this.gameObject.GetComponent<BuildPlacementHandler>().getBuildingSpot() != null)
        {
            GameObject emptySpot = this.gameObject.GetComponent<BuildPlacementHandler>().getBuildingSpot();
            if (emptySpot.GetComponent<BuildingManagement>().CanPlaceBuilding)
            {
                emptySpot.GetComponent<BuildingManagement>().InsertBuilding(previewedBuilding);
                emptySpot.transform.tag = "BuildingSpot";
                placingBuilding = false;
                previewedBuilding = null;
            }
        }
    }
}
