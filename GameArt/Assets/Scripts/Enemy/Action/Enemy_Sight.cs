using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sight : MonoBehaviour {

    private Enemy_shooting shooting;

	// Use this for initialization
	void Start () {
        shooting = GetComponentInParent<Enemy_shooting>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shooting.Shoot();
        }
    }
}
