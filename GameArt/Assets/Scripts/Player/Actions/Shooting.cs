using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public float attSpeed;
    public Transform shotPos;
    float timer;
    public GameObject bullet;


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && timer <= 0)
        {
            timer = attSpeed;
            Shoot();
        }
    }

    void Shoot()
    {
            Instantiate(bullet, shotPos.position, shotPos.rotation);

    }
}

