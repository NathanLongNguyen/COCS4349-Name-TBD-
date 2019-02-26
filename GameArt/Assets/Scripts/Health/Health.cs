using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHealth; 
    public float regenTimer; //set how fast the regen is 
    float timer;
    public int curHealth, regenRate; //regenRate is the rate at which health regens at


	// Use this for initialization
	void Start () {
        timer = regenTimer;
        curHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(curHealth);
        if(curHealth < maxHealth && curHealth >0) //if player's health is not at full and still alive, then they're able to regen health
        {
            Regen();
        } else if (curHealth <= 0) //death when player's health reaches zero
        {
            Death();
        }
	}

    //Function for taking damage
    public void takeDamage(int dam) //function is made to public so that other scripts can access it 
    {
        curHealth -=  dam;
        if (curHealth < 0)
        {
            Death();
        }
    }

    //Function for health regen
    void Regen()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            curHealth += regenRate;
            timer = regenTimer;
        }
    }

    //Function for death
    void Death()
    {
        Destroy(gameObject); //Placeholder
    }
}
