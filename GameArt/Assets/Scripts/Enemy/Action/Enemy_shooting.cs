using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shooting : MonoBehaviour {


    public Transform shotPos;
    public GameObject bulletPre;
    public float fireRate;
    float timer;
    bool canShoot;

	// Use this for initialization
	void Start () {
        
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            canShoot = true;
        }
  
	}

    public void Shoot()
    {
        if (canShoot)
        {
            Instantiate(bulletPre, shotPos.position, shotPos.rotation);
            timer = fireRate;
            canShoot = false;
        }
    }
}
