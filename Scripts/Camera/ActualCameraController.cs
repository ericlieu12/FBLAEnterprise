using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualCameraController : MonoBehaviour
{
    public Transform target;

    [System.Serializable]
    public class PositionSettings
    {
        public Vector3 targetPosOffset = new Vector3(0, 0, 0); // Note: This will change depending on where the character is
        public float lookSmooth = 100f;
        public float distanceFromTarget = -8; //This is the default distance from the player. (negative means behind).
        public float zoomSpeed = 10; // Note: This can change. Zoom speed.
        public float maxZoom = -2; //This is the maximum zoom you can have.
        public float minZoom = -15; //This is the minimum zoom you can have.
    }

    [System.Serializable]
    public class OrbitSettings
    {
        public float xRotation = -20; //The actualy X Rotation
        public float yRotation = -180; //The actual Y Rotation
        public float maxXRotation = 25; //Max rotation on the X-axis
        public float minXRotation = -85; //Max rotation on the Y-axis
        public float vOrbitSmooth = 150; // This is orbiting speed with the numpad
        public float hOrbitSmooth = 150; // This is orbiting speed with the numpad
    }

    [System.Serializable]
    public class InputSettings //Defines the input settings we use for the numpad
    {
        public string ORBIT_HORIZONTAL_SNAP = "OrbitHorizontalSnap";
        public string ORBIT_HORIZONTAL = "OrbitHorizontal";
        public string ORBIT_VERTICAL = "OrbitVertical";
        public string ZOOM = "Scroll";
    }

    public PositionSettings position = new PositionSettings(); //creates new objects.
    public OrbitSettings orbit = new OrbitSettings(); //creates new objects.
    public InputSettings input = new InputSettings(); //creates new objects.

    Vector3 targetPos = Vector3.zero; //This creates the targetPos variable
    Vector3 destination = Vector3.zero; //This creates the destination variable
    CharacterController charController; //This creates the variable for the characterController
    float vOrbitInput, hOrbitInput, zoomInput, hOrbitSnapInput;

    private void Start()
    {
        SetCameraTarget(target);
        MoveToTarget();
        transform.position = destination;
    }

    void SetCameraTarget(Transform t)
    {
        target = t; //takes in the parameter that is "t" which is a transform object and saves it into target.

        if (target != null) //Checks if there is valid parameter that is passed in.
        {
            if (target.GetComponent<CharacterController>()) //checks if the player contains the CharacterController script
            {
                charController = target.GetComponent<CharacterController>(); //if true saves the script into the varaible.
            }
            else
                Debug.LogError("The camera's target needs a character controller."); //Checks for error if there is no CharacterController Script.
        }
        else
            Debug.LogError("Your camera needs a target."); //No target has been assigned to the script.
    }

    void GetInput() //Gets the input from the update to change the camera to its correct position
    {
        vOrbitInput = Input.GetAxisRaw(input.ORBIT_VERTICAL); 
        hOrbitInput = Input.GetAxisRaw(input.ORBIT_HORIZONTAL);
        hOrbitSnapInput = Input.GetAxisRaw(input.ORBIT_HORIZONTAL_SNAP);
        zoomInput = Input.GetAxisRaw(input.ZOOM);
    }

    private void Update() //This function is called every frame
    {
        GetInput(); //Ensures that the camera is matching the user input
        ZoomInOnTarget(); //Checks to see if the user has made a zoom adjustment
    }

    private void FixedUpdate() //This function is what is displayed on screen
    {
        //moving
        MoveToTarget();
        //rotating
        LookAtTarget();
        //orbtiing
        OrbitTarget();
    }

    void MoveToTarget() //Moves to target
    {
        targetPos = target.position + position.targetPosOffset;
        destination = Quaternion.Euler(orbit.xRotation, orbit.yRotation + target.eulerAngles.y, 0) * -Vector3.forward * position.distanceFromTarget;
        destination += targetPos;
        transform.position = destination; // Without this line of code, the camera zooms in on the character and the user cannot do anything about it
    }

    void LookAtTarget() //looks at target
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetPos - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, position.lookSmooth * Time.deltaTime);
    }

    void OrbitTarget() //orbits the target
    {
        if (hOrbitSnapInput > 0)
        {
            orbit.yRotation = -180;
        }

        orbit.xRotation += -vOrbitInput * orbit.vOrbitSmooth * Time.deltaTime;
        orbit.yRotation += -hOrbitInput * orbit.hOrbitSmooth * Time.deltaTime;

        if (orbit.xRotation > orbit.maxXRotation)
        {
            orbit.xRotation = orbit.maxXRotation; //This ensures the rotation does not exceed Max X Rotation.
        }
        if (orbit.xRotation < orbit.minXRotation)
        {
            orbit.xRotation = orbit.minXRotation; //This ensures the rotation does not fall below Min X Rotation.
        }
    }

    void ZoomInOnTarget() //Zooms on taret
    {
        position.distanceFromTarget += zoomInput * position.zoomSpeed * Time.deltaTime;

        if (position.distanceFromTarget > position.maxZoom)
        {
            position.distanceFromTarget = position.maxZoom; //This ensures that the camera is not exceeding the max zoom.
        }

        if (position.distanceFromTarget < position.minZoom)
        {
            position.distanceFromTarget = position.minZoom; //This ensures that the camera is not falling below the minmum zoom.
        }
    }
}
