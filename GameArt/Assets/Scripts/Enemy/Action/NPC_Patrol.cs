using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Patrol : MonoBehaviour {

    [SerializeField]
    float WaitTime;

    
    public List<Waypoint> patrolPoints;

    NavMeshAgent navMeshAgent;
    int currentPatrolIndex;
    bool traveling;
    bool waiting;
    bool patrolForward;
    float waitTimer;

    // Use this for initialization
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.Log("WHERE IS IT????");
        }
        else
        {
            if (patrolPoints != null && patrolPoints.Count >= 2)
            {
                currentPatrolIndex = 0;
                SetDestination();
            }
        }
    }

    // Update is called once per frame
    void SetDestination()
    {

    }
}

