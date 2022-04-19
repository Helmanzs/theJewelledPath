using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    void Start()
    {
        agent.updateRotation = true;
        agent.SetDestination(Global.Instance.endTile.transform.position);
    }
}
