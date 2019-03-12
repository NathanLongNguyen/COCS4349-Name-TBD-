using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attaching the camera to the player; defining bounds to determine when camera should move
//according to player
public class CameraMove : MonoBehaviour {

    public Transform current;
    public float xBound = 2.0f; //set to public to allow editing in unity
    public float yBound = 1.5f;
    public float speed = 0.15f;

    private Vector3 smoothingPosition;
    
    //The video suggested LateUpdate(), no difference seen yet, need more testing
    private void Update()
    {
        Vector3 delta = Vector3.zero;

        //Checking the X axis
        float deltaX = current.position.x - transform.position.x;
        //Checking bounds
        if (deltaX > xBound || deltaX < -xBound)
        {
            //checking if we are on the right side
            if (transform.position.x < current.position.x)
            {
                delta.x = deltaX - xBound;
            }
            else
            {
                delta.x = deltaX + xBound;
            }
        }

        //Checking the Y axis
        float deltaY = current.position.y - transform.position.y;
        //Checking bounds
        if (deltaY > yBound || deltaY < -yBound)
        {
            //checking if we are on the right side
            if (transform.position.y < current.position.y)
            {
                delta.y = deltaY - yBound;
            }
            else
            {
                delta.y = deltaY + yBound;
            }
        }

        //Moving the camera
        smoothingPosition = transform.position + delta;
        //Creating a "smoother" transition/movement with Lerp
        transform.position = Vector3.Lerp(transform.position, smoothingPosition, speed);
    }
}
