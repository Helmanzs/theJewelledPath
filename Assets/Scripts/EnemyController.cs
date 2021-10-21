using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject endTile;
    public NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(endTile.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
