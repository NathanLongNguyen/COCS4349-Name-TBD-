using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHealth;
    public float regenTimer;
    float timer;
    public int curHealth, regenRate;


	// Use this for initialization
	void Start () {
        timer = regenTimer;
        curHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(curHealth);
        if(curHealth < maxHealth && curHealth >0)
        {
            Regen();
        } else if (curHealth <= 0)
        {
            Death();
        }
	}

    public void takeDamage(int dam)
    {
        curHealth -=  dam;
        if (curHealth < 0)
        {
            Death();
        }
    }

    void Regen()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            curHealth += regenRate;
            timer = regenTimer;
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
