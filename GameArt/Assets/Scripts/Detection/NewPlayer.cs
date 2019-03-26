using UnityEngine;
using System.Collections;

public class NewPlayer : MonoBehaviour
{
    public GameObject sun;

    private MeshRenderer mesh;
    private RaycastHit hit;
    private bool underSun = false;

    // Use this for initialization
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        underSun = false;
        Vector3 sunDir = sun.transform.forward;
        sunDir.Normalize();
        sunDir *= 20;

        //foreach ()
        //{
            if (!Physics.Raycast(transform.position, -1f * sunDir, 30, LayerMask.GetMask("Ground")))
            {
                Debug.DrawLine(transform.position, transform.position - sunDir, Color.red);
                underSun = true;
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position - sunDir, Color.green);
            }

        //}

        if (underSun)
        {
            mesh.material.color = Color.red;
        }
        else
        {
            mesh.material.color = Color.green;
        }
    }
}


