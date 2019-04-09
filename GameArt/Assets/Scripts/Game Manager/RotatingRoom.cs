using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRoom : MonoBehaviour
{
    public PlayerController player;

    void Start()
    {
        //StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSecondsRealtime(3);
        Debug.Log("Done waiting 1");

        player.FreezeChar();
        GameObject.Find("Player(Cube)").GetComponent<PlayerController>().enabled = false;
        //rotateRoom();
        yield return new WaitForSecondsRealtime(6);
        Debug.Log("Done waiting 2");

        player.UnfreezeChar();
        GameObject.Find("Player(Cube)").GetComponent<PlayerController>().enabled = true;

        /*Time.timeScale = 0f;
        transform.RotateAround(transform.position, transform.forward, Time.deltaTime * 90f);
        yield return new WaitForSecondsRealtime(1);
        Debug.Log("Done waiting 2");
        Time.timeScale = 1f;

        yield return new WaitForSecondsRealtime(3);
        Debug.Log("Done waiting 3");

        Time.timeScale = 0f;
        transform.Rotate(new Vector3(0, 0, 180), Space.Self);
        yield return new WaitForSecondsRealtime(1);
        Debug.Log("Done waiting 4");
        Time.timeScale = 1f;*/

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
        player.UnfreezeChar();
        GameObject.Find("Player(Cube)").GetComponent<PlayerController>().enabled = true;
        yield return null;

    }

    void Update()
    {
        //transform.Rotate(new Vector3(0, 0, 15) * Time.deltaTime);
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
