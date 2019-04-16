using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Vector3 gravityForce = new Vector3(0f, 9.8f, 0f);
    void OnTriggerStay(Collider other)
    {
        other.attachedRigidbody.useGravity = false;
        if (other.attachedRigidbody /* || some other check here too! */)
        {
            
            other.attachedRigidbody.AddForce(transform.TransformDirection(gravityForce), ForceMode.Acceleration);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.attachedRigidbody.useGravity = true;
    }
}
