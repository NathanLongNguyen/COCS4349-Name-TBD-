using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rotates the pick-up to give it movement
//Requires the transform rotation to be ALREADY set (45, 45, 45)
//Do not want to set the transform rotation, want to rotate the transform
public class Rotator : MonoBehaviour {

	// Update is called once per frame
    // Using Update and not fixedUpdate because we are not using forces
	void Update () {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
