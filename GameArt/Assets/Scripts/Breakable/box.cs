using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour {

    int boxHealth = 3;
    string status = "idle";
    Renderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        switch (status)
        {
            case "idle": //act like a box
                break;
            case "damaged": //box is damaged, update color
                boxHealth--;
                if (boxHealth > 0)
                {
                    if (boxHealth == 2)
                        rend.material.SetColor("_Color", Color.yellow);
                    else if (boxHealth == 1)
                        rend.material.SetColor("_Color", Color.red);
                }
                else //if box health is <= 0, destroy box
                {
                    Destroy(gameObject);
                }
                status = "idle"; //reset box status
                break;
            default: //Error check
                Debug.Log("Error with box --- destroying object");
                Destroy(gameObject);
                break;
        }
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) //if box is damaged, set status to damaged
        {
            status = "damaged";
        }
    }
}
