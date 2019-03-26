using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pit : MonoBehaviour
{

    private Health playerHealth;

    // Use this for initialization
    void Start()
    {
        playerHealth = GameObject.Find("Player(Cube)").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit");
            playerHealth.takeDamage(playerHealth.maxHealth);
        }


    }
}