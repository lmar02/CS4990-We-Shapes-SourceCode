using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Vector3 pos1;
    private Vector3 pos2;
    private bool backward = false;

    public float speed = 0.1f;
    public float distance = 10f;
    public string direction = "Forward";
    public float waitTime = 4f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the initial position.
        pos1 = transform.position;

        // Set the second position based on the direction of the movement.
        switch (direction.ToLower())
        {
            case "forward":
                pos2 = pos1 + new Vector3(0, 0, distance);
                break;
            case "backward":
                pos2 = pos1 + new Vector3(0, 0, -distance);
                break;
            case "left":
                pos2 = pos1 + new Vector3(-distance, 0, 0);
                break;
            case "right":
                pos2 = pos1 + new Vector3(distance, 0, 0);
                break;
            case "up":
                pos2 = pos1 + new Vector3(0, distance, 0);
                break;
            case "down":
                pos2 = pos1 + new Vector3(0, -distance, 0);
                break;

            // We want an error to happen if the direction isn't set right.
            default:
                Debug.LogError("Invalid direction given to moving platform.");
                pos2 = pos1;
                break;
        }

        Invoke("PlatformMove", waitTime);

    }

    void PlatformMove()
    {

        switch (backward)
        {
            case true:
                transform.position = Vector3.MoveTowards(transform.position, pos1, speed * 0.1f);
                if (transform.position == pos1)
                {
                    backward = false;
                    Invoke("PlatformMove", waitTime);
                    return;
                }
                break;
            default:
                transform.position = Vector3.MoveTowards(transform.position, pos2, speed * 0.1f);
                if (transform.position == pos2)
                {
                    backward = true;
                    Invoke("PlatformMove", waitTime);
                    return;
                }
                break;
        }

        Invoke("PlatformMove", 0.006f);
    }

    private void OnTriggerStay(Collider other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
