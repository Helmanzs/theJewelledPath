using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameBoard : MonoBehaviour
{
    public BuildingSpot buildingSpot;
    public BuildingSpot pathBuildingSpot;
    public EndTile endSpot;
    public SpawnTile spawnSpot;
    public GameObject paths;
    public GameObject spots;

    public Texture2D level;

    private float gameTileWidth = 0;
    private float gameTileHeight = 0;
    void Start()
    {
        GenerateLevel(level);
        Time.timeScale = 1f;
        FindObjectOfType<NavMeshSurface>().BuildNavMesh();
    }

    public void GenerateLevel(Texture2D level)
    {
        if (level.name == "level09")
        {
            GetComponent<AudioSource>().Play();
        }
        level = level.RotateTexture(false);
        transform.localScale = new Vector3(2 * level.width, 1, 2 * level.height);
        transform.position = new Vector3(level.width, 0, level.height);
        gameTileWidth = transform.localScale.x / level.width;
        gameTileHeight = transform.localScale.z / level.height;
        GetComponent<Renderer>().material.mainTextureScale = new Vector2(level.width, level.height);
        Color color;
        for (int i = 0; i < level.width; i++)
        {
            for (int j = 0; j < level.height; j++)
            {
                color = level.GetPixel(i, j);
                if (color == Color.black)
                    GenerateBuildingSpot(i, j);

                if (color == Color.white)
                    GeneratePathSpot(i, j);

                if (color == Color.red)
                    GenerateEndSpot(i, j);

                if (color == Color.green)
                    GenerateSpawnSpot(i, j);
            }
        }

        RenameBuildingSpots();
    }
    private void GenerateBuildingSpot(int i, int j)
    {
        BuildingSpot spot = Instantiate(buildingSpot, new Vector3(i * gameTileWidth + gameTileWidth / 2, 0.51f, j * gameTileHeight + gameTileHeight / 2), Quaternion.identity);
        spot.transform.localScale = new Vector3(gameTileWidth / 10, 0.01f, gameTileHeight / 10);
        Global.Instance.buildingSpots.Add(spot);
        spot.transform.SetParent(spots.transform);
    }

    private void GenerateSpawnSpot(int i, int j)
    {
        SpawnTile spawnTile = Instantiate(spawnSpot, new Vector3(i * gameTileWidth + gameTileWidth / 2, 0.51f, j * gameTileHeight + gameTileHeight / 2), Quaternion.identity);
        spawnTile.transform.localScale = new Vector3(gameTileWidth / 10, 0.01f, gameTileHeight / 10);
        Global.Instance.spawnTile = spawnTile;
        spawnTile.transform.SetParent(spots.transform);
    }

    private void GenerateEndSpot(int i, int j)
    {
        EndTile endTile = Instantiate(endSpot, new Vector3(i * gameTileWidth + gameTileWidth / 2, 0.51f, j * gameTileHeight + gameTileHeight / 2), Quaternion.identity);
        endTile.transform.localScale = new Vector3(gameTileWidth / 10, 0.01f, gameTileHeight / 10);
        Global.Instance.endTile = endTile;
        endTile.transform.SetParent(paths.transform);
    }

    private void GeneratePathSpot(int i, int j)
    {
        BuildingSpot spot = Instantiate(pathBuildingSpot, new Vector3(i * gameTileWidth + gameTileWidth / 2, 0.51f, j * gameTileHeight + gameTileHeight / 2), Quaternion.identity);
        spot.transform.localScale = new Vector3(gameTileWidth / 10, 0.01f, gameTileHeight / 10);
        Global.Instance.buildingSpots.Add(spot);
        spot.transform.SetParent(paths.transform);
    }

    private void RenameBuildingSpots()
    {
        for (int i = 0; i < Global.Instance.buildingSpots.Count; i++)
        {
            if (Global.Instance.buildingSpots[i].tag == "EmptyBuildingSpot")
            {
                Global.Instance.buildingSpots[i].name = $"BuildingSpot-{i}";
            }
        }
    }


}
