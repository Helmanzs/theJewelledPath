using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    void Start()
    {
        agent.SetDestination(Global.Instance.endTile.transform.position);
    }
}
