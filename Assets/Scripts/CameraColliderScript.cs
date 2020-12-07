using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColliderScript : MonoBehaviour
{

    public float cameraAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Disable the drawing of this box when the game is running.
        GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // TODO: Lerp camera angle or something.
        Debug.Log( "(NOT IMPLEMENTED) Setting camera angle to: " + cameraAngle.ToString() );
    }

}
