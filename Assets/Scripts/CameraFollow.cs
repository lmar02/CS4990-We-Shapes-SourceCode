using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

	public float speed = 0.125f;
	public Vector3 offset;

	void FixedUpdate ()
	{
        // We move the camera to the target.
        // TODO: Rotation. This won't work for that.
		Vector3 _positionToGo = target.position + offset;
		Vector3 _smoothedPosition = Vector3.Lerp(transform.position, _positionToGo, speed);
		transform.position = _smoothedPosition;
	}
}
