using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    // We want to use this to rotate the camera later.
    public Transform cameraTransform;
    private Rigidbody playerRigidbody;

    // Player Movement Vector
    private Vector3 inputVector;

    public bool playerInControl = true;

    private float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {

        // Attempt to get the camera's transform if we don't already have it.
        if (cameraTransform == null)
        {
            Debug.LogWarning("Camera was not assigned, attempting to find it.");

            var _tempObject = GameObject.Find("Main Camera");

            if (_tempObject != null)
            {
                cameraTransform = _tempObject.transform;
                Debug.Log("Camera found and assigned.");
            }
            else
            {
                Debug.LogError("Unable to get the Camera!");
            }            
        }

        playerRigidbody = GetComponent<Rigidbody>();


    }

    void PlayerMovement()
    {
        // If this isn't the controlled object, stop.
        if ( !playerInControl ) { return; }

        bool _ground = false;

        // A bunch of raycasts to see if the ground exists.
        bool _groundCenter = Physics.Raycast(playerRigidbody.position, Vector3.down, 2);

        bool _groundForward = Physics.Raycast(playerRigidbody.position + Vector3.forward + Vector3.left, Vector3.down, 1);
        bool _groundBackward = Physics.Raycast(playerRigidbody.position + Vector3.forward + Vector3.right, Vector3.down, 1);
        bool _groundLeft = Physics.Raycast(playerRigidbody.position + Vector3.back + Vector3.left, Vector3.down, 1);
        bool _groundRight = Physics.Raycast(playerRigidbody.position + Vector3.back + Vector3.right, Vector3.down, 1);

        // Draw them in the scene view.
        Debug.DrawRay(playerRigidbody.position, Vector3.down, Color.red);
        Debug.DrawRay(playerRigidbody.position + Vector3.forward + Vector3.left, Vector3.down, Color.red);
        Debug.DrawRay(playerRigidbody.position + Vector3.forward + Vector3.right, Vector3.down, Color.red);
        Debug.DrawRay(playerRigidbody.position + Vector3.back + Vector3.left, Vector3.down, Color.red);
        Debug.DrawRay(playerRigidbody.position + Vector3.back + Vector3.right, Vector3.down, Color.red);

        if (!_groundCenter && !_groundForward && !_groundBackward && !_groundLeft && !_groundRight)
        {
            _ground = false;
        }
        else
        {
            _ground = true;
        }

        // Prevent player movement if you are not on the ground.
        if (!_ground) { return; }

        // Get the input of the player.
        float _inputH = Input.GetAxis("Horizontal");
        float _inputV = Input.GetAxis("Vertical");

        Vector3 _inputs = new Vector3(_inputH, 0, _inputV);

        // Get the rotation of the camera.
        float _cameraAngle = cameraTransform.eulerAngles.y;

        // Create the final rotation from what we have.
        Vector3 _finalRotation = Quaternion.Euler(0, _cameraAngle, 0) * _inputs;

        // If we don't want to go anywhere, stop running code.
        if (_finalRotation == Vector3.zero) { return; }

        Vector3 _targetPosition = playerRigidbody.position + (_finalRotation * speed * Time.deltaTime);

        // We get the temporary locations so we can point the shape.
        var _tempLoc = playerRigidbody.position;

        // Move the rigidbody.
        playerRigidbody.MovePosition(_targetPosition);

        var _tempLoc2 = playerRigidbody.position;

        // Figure out where we are going, and rotate to face there.
        var _targetDirection = _tempLoc2 - _tempLoc;
        var _targetRotation = Vector3.RotateTowards(transform.forward, _targetDirection, speed * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(_targetRotation);

    }


    // Update is called once per frame
    void FixedUpdate()
    {

        PlayerMovement();

    }
}
