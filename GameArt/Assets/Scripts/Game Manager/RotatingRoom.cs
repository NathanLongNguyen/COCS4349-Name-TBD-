using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRoom : MonoBehaviour
{
    public PlayerController player;
    private Vector3 center = new Vector3(0, 0, 0);

    void Start()
    {
        //center.x = (transform.GetChild(0).position.x + transform.GetChild(1).position.x + transform.GetChild(2).position.x + transform.GetChild(3).position.x) / 4;
        //center.y = (transform.GetChild(0).position.y + transform.GetChild(1).position.y + transform.GetChild(2).position.y + transform.GetChild(3).position.y) / 4;
        //transform.position = center;
        //transform.position = transform.GetComponent<Collider>().bounds.center;
        //needs a renderer/collider component

        //Physics.gravity = new Vector3(-9.81f, 0f, 0f);
    }

    IEnumerator Rotate(Vector3 byAngles, float inTime)
    {
        Quaternion fromAngle = transform.rotation;
        Quaternion toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        player.FreezeChar();
        GameObject.Find("Player(Cube)").GetComponent<PlayerController>().enabled = false;
        
        for (float i = 0f; i < 1f; i+= Time.deltaTime/ inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, i);
            yield return null;

        }
        transform.rotation = toAngle;
        player.UnfreezeChar();
        GameObject.Find("Player(Cube)").GetComponent<PlayerController>().enabled = true;
        yield return null;
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            StartCoroutine(Rotate(Vector3.forward * 90, 0.8f));
        }
        if (Input.GetKeyDown("q"))
        {
            StartCoroutine(Rotate(Vector3.forward * -90, 0.8f));
        }
    }
}
