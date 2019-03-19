using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the Laser Sight for the player's aim
/// </summary>
public class TrajectorySimulation : MonoBehaviour
{
    // Reference to the LineRenderer we will use to display the simulated path
    public LineRenderer sightLine;

    // Reference to a Component that holds information about fire strength, location of cannon, etc.
    public GameObject gun;

    void Start()
    {
    }

    void Update()
    {
        Vector3 ray = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector3 gunPos = new Vector2(gun.transform.position.x, gun.transform.position.y);
        //Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        sightLine.SetPosition(0, gunPos);
        sightLine.SetPosition(1, ray);
    }
}