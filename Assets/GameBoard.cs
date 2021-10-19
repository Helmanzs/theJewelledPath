using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public GameObject towerSpot;
    public GameObject tower;
    int[,] grid = new int[4,4];
    List<GameObject> towerSpots = new List<GameObject>();
    private float gameTileWidth = 0;
    private float gameTileHeight = 0;

    private void Awake() {
        gameTileWidth = (this.transform.localScale.x / grid.GetLength(0));
        gameTileHeight = (this.transform.localScale.z / grid.GetLength(1));
    }

    void Start()
    {
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
        if(towerSpots.FindAll(t => t.GetComponent<TowerManagement>().CanPlace).Count == 0){
            Debug.Log("Nejsou volná místa.");
            return;
        }

        var random = towerSpots[Random.Range(0, towerSpots.Count)];
        if(random.GetComponent<TowerManagement>().CanPlace){
            random.GetComponent<TowerManagement>().InsertTower(tower);
        } else {
            AddTower();
        }

    }
}
