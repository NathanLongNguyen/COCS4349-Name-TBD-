using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Spawner will spawn a cube in every x number of seconds
public class Spawner : MonoBehaviour {
    public GameObject prefab;
    public float repeatTime = 3f;

    void Start()
    {
        InvokeRepeating("Spawn", 2f, repeatTime);
        
    }

    void Spawn()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
