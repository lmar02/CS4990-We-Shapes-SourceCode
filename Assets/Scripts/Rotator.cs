/* ****************************************************
 * File:		Rotator
 * Purpose:		To constantly rotate Pick Up
 * Programmer:	Wade Falk
 * Date:		September 24th, 2020
 *************************************************** */

using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour 
{

	// Add speeds so we can change them - Sean
	public float xSpeed = 0f;
	public float ySpeed = 30f;
	public float zSpeed = 0f;

	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (new Vector3 (xSpeed, ySpeed, zSpeed) * Time.deltaTime);
	} // end Update ()
} // end Rotator
