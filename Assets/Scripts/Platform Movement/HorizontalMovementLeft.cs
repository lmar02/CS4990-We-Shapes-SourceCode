using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovementLeft : MonoBehaviour
{

    //This movement starts on the left and move to the right

    private Vector3 pos1;
    private Vector3 pos2;


    public float speed = 0.01f;


    // Start is called before the first frame update

    private void OnTriggerStay(Collider other)
    {
        other.transform.SetParent(transform);
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
    private void Start()
    {
        pos1 = transform.position;
        pos2 = pos1;
        pos2.z = pos1.z + 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
