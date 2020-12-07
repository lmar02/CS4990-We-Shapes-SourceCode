using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovementUp : MonoBehaviour
{

    //This makes the platform move up
    private Vector3 pos1;
    private Vector3 pos2;

	// This determines if triggered by collectible (Wade)
	public bool requiresCollectible = false;
	public GameObject collectible;
	
	public bool pauseAtEnd = false;			// This prevents PingPong (Wade)
	public float upValue = 10.0f;			// Edit value for pos2 (Wade)
    public float speed = 1f;

    private void OnTriggerStay(Collider other)
    {
        other.transform.SetParent(transform);
    } // end OnTriggerEnter

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    } // end OnTriggerExit
	
    // Start is called before the first frame update
    private void Start()
    {
        pos1 = transform.position;
        pos2 = pos1;
        pos2.y = pos1.y + upValue;
    } // end Start

    // Update is called once per frame
	void Update()
	{
		if ((requiresCollectible == true && collectible == null) ||
		    (requiresCollectible == false)) {
			
			if (pauseAtEnd == false) {
				transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong (Time.time * speed, 1.0f));
			} else {
				while (transform.position.y < pos2.y) {
					transform.position = Vector3.Lerp (pos1, pos2, speed);
				} // end while
			} // end if
		} // end if
	} // end Update
} // end VerticalMovementUp
