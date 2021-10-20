using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public GameObject towerSpot;
    public GameObject tower;

    private int[,] grid = new int[32,32];
    List<GameObject> towerSpots = new List<GameObject>();
    private float gameTileWidth = 0;
    private float gameTileHeight = 0;


    private void Awake() {

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
        //setup grid
        for (int i = 0; i < grid.GetLength(0); i++){
            for (int j = 0; j < grid.GetLength(1); j++){

                spot = Instantiate(towerSpot, new Vector3(i * gameTileWidth + gameTileHeight/2, 0, j * gameTileHeight + gameTileHeight/2), Quaternion.identity);
                spot.transform.localScale = new Vector3(gameTileWidth / 10, 0.01f, gameTileHeight / 10);
                towerSpots.Add(spot);

            }
        }
    }

 
    void Update()
    {
        
    }

    public void AddTower(){

        //check if tower can be placed on towerSpot
        if(towerSpots.FindAll(t => t.GetComponent<TowerManagement>().CanPlace).Count == 0){
            Debug.Log("Nejsou volná místa.");
            return;
        }


        //TODO: make it on player mouse movement and click
        //place tower on random towerspot
        var random = towerSpots[Random.Range(0, towerSpots.Count)];
        if(random.GetComponent<TowerManagement>().CanPlace){
            random.GetComponent<TowerManagement>().InsertTower(tower);
        } else {
            AddTower();
        }

    }
}
