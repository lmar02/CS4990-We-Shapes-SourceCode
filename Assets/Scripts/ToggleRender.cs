/* ****************************************************
 * File:		ToggleRender
 * Purpose:		To toggle game object's rendering & rb
 * Programmer:	Wade Falk
 * Date:		September 23rd, 2020
 *************************************************** */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRender : MonoBehaviour
{
	public bool isActive;

	// toggle the rendering of the object once triggered to do so - Wade
	public void ToggleVisibility(){

		Renderer rend = gameObject.GetComponent<Renderer> ();
		Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
		
		if (!isActive) {
			rend.enabled = false;
			rb.isKinematic = false;
		} 
		else {
			rend.enabled = true;
			rb.isKinematic = true;
		} // end if
	} // end ToggleVisibility
} // end ToggleRender class
