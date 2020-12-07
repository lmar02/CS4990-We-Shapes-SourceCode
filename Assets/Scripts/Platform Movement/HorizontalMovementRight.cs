using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HorizontalMovementRight : MonoBehaviour
{

    // This platform starts on the Right and moves to the left. 
    private Vector3 pos1;
    private Vector3 pos2;
    

    public float speed = 0.01f;

    private void OnTriggerStay(Collider other)
    {
        other.transform.SetParent(transform);
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }

    // Start is called before the first frame update
    private void Start()
    {
        pos1 = transform.position;
        pos2 = pos1;
        pos2.x = pos1.x - 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
