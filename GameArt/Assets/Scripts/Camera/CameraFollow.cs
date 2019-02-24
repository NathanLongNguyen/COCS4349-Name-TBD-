using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothing;
    public float z_offset, y_offset;

	// Use this for initialization
	void Start () {
        z_offset = transform.position.z - target.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        Vector3 cameraPos = new Vector3(target.position.x, target.position.y + y_offset, z_offset);
        transform.position = Vector3.Lerp(transform.position, cameraPos, smoothing * Time.deltaTime);
    }
}
