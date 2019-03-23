using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy_movement : MonoBehaviour {

    [SerializeField]
    Transform Destination1, Destination2;

    NavMeshAgent navMeshAgent;
    

	// Use this for initialization
	void Start () {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(navMeshAgent == null)
        {
            Debug.Log("WHERE IS IT????");
        }
        else
        {
            SetDestination();
        }
	}
	
	// Update is called once per frame
	void SetDestination()
    {
        if(Destination1 != null)
        {
            Vector3 target = Destination1.transform.position;
            navMeshAgent.SetDestination(target);
        }
    }


}
