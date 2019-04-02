using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindLights : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var foundObjects = FindObjectsOfType<Light>();
            Debug.Log(foundObjects + " : " + foundObjects.Length);
        }
    }
}
