/* *************************************************************
 * File:		TelepadLogic.cs
 * Purpose:		Upon enter teleports "Player" tagged GameObject
 *               to linked telepad.
 * Programmer:	Wade Falk
 * Date:		October 12th, 2020
 ************************************************************ */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelepadLogic : MonoBehaviour
{
	public bool isExitTelepad = false;	// Checks if exit telepad
	public GameObject exitTelepad;		// Set as null when exit telepad; Links to exit

	private Vector3 exitPos;

    // Start is called before the first frame update
    void Start()
    {
		// Set exitPos; 
		// if exitpad, no teleport but handles any error for exitPos being null
		exitPos = GetComponent<Transform> ().position;

		if (exitTelepad != null) {
			exitPos = exitTelepad.transform.position;
		} // end if

		exitPos.y += 2f; 				// Prevent collision with telepad in Update
    } // end Start

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        // Teleport Player to Exit Telepad!
        if (isExitTelepad == false && other.gameObject.tag == "Player")
        {
            other.transform.position = exitPos;
        }
		 // end if
    } // end OnTriggerEnter
} // end TelepadLogic class
