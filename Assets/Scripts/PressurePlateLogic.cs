/* *****************************************************
 * File:		PressurePlateLogic
 * Purpose:		To have a pressure plate object trigger
 * 					a reveal via ToggleRender.cs
 * Programmer:	Wade Falk
 * Date:		September 23rd, 2020
 **************************************************** */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateLogic : MonoBehaviour
{
	// Object changed due to pressure plate being triggered; Must have ToggleRender component - Wade
	[SerializeField]
	GameObject triggerObject;

	private float timer;
	private ToggleRender render;

	private void Start() {

		if (triggerObject = null) {
			triggerObject = GameObject.Find("Victory Flag"); // Default value = Flag - Wade
		} // end if

		// if triggerObject doesn't have a ToggleRender component, add it and set false - Wade
		if (triggerObject.GetComponent<ToggleRender> () == null) {
			triggerObject.AddComponent<ToggleRender> ();
		} // end if

		render = triggerObject.GetComponent<ToggleRender> ();
		render.isActive = false;
	} // end Start

	private void Update() {

		// Countdown timer to be <= 0; See OnTriggerExit for more - Wade
		if (timer > 0) {
			timer -= Time.deltaTime;
			if (timer 	<= 0f) { render.isActive = false; }
		} // end if
	} // end Update

	private void OnTriggerEnter(Collider col){
		if (col.gameObject) {
			render.isActive = true;
			timer = 1f;
		} // end if
	} // end OnTriggerEnter

	private void OnTriggerStay(Collider col){

		// Ensure rendering remains while an object remains on pressure plate - Wade
		render.isActive = true;
		timer = 1f;
	} // end OnTriggerStay

	private void OnTriggerExit(Collider col){

		if (col.gameObject) {

			// Set triggerObject to disappears once timer <= 0 - Wade
			if (timer <= 0f) { render.isActive = false; }
		} // end if
	} // end
} // end PressurePlatLogic class
