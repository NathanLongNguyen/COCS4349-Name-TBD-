using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect_Edge : MonoBehaviour {

    public GameObject enemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Edge"))
        {
            Quaternion flip = enemy.transform.localRotation;
            flip.y -= 180;
            enemy.transform.localRotation = flip;
            Debug.Log("hit");
        }
    }
}
