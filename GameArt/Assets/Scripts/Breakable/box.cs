using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour {

    int boxHealth = 3;
    Renderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        switch (boxHealth)
        {
            case 3:
                rend.material.SetColor("_Color", Color.green);
                break;
            case 2:
                rend.material.SetColor("_Color", Color.yellow);
                break;
            case 1:
                rend.material.SetColor("_Color", Color.red);
                break;
            default:
                Destroy(gameObject);
                break;
        }
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            boxHealth--;
            //Destroy(gameObject);
        }
    }
}
