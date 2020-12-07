/* *************************************************************
 * File:		Rotator
 * Purpose:		To reset an object that went Out-of-bounds (OOB)
 * Programmer:	Wade Falk
 * Date:		September 24th, 2020
 ************************************************************ */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOBReset : MonoBehaviour
{
	[SerializeField]
	float maxFallDistance = -5.5f; // Editable fall distance before reset

	private Transform originalPos;
	private Transform currentPos;
	private Vector3 resetPos;

    void Start()
    {
		// Set position; 
		// resetPos will drop the object from 10 units up to prevent collisions
		originalPos = GetComponent<Transform> ();
		resetPos = originalPos.position;
		resetPos.y += 10f;
    } // end Start

    // Update is called once per frame
    void Update()
    {
		currentPos = GetComponent<Transform> ();

		// Check to reset object's position
        if (currentPos.position.y <= maxFallDistance) {
			currentPos.position = resetPos;
		} // end if
    } // end Update
} // end OOBReset
