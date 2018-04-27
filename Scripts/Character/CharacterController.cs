using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    // Note: DistanceToGrounded must be greater than 0.9
    // Note: Make sure to freeze rotation
    // Note: Make sure gravity is off on rigidbody
    // Note: Make sure the collider goes below/encapsulates the origin of the character

    [System.Serializable] //Allows class values to be seen from the inspector
    public class MoveSettings
    {
        public float forwardVel = 12;
        public float rotateVel = 100;
        public float jumpVel = 25;
        public float distToGrounded = 0.1f;
        public LayerMask ground;
    }

    [System.Serializable] //Allows class values to be seen from the inspector
    public class PhysSettings
    {
        public float downAccel = 0.75f;
    }

    [System.Serializable] //Allows class values to be seen from the inspector
    public class InputSettings
    {
        public float inputDelay = 0.1f;
        public string FORWARD_AXIS = "Vertical";
        public string TURN_AXIS = "Horizontal";
        public string JUMP_AXIS = "Jump";
    }

    public MoveSettings moveSetting = new MoveSettings();
    public PhysSettings physSetting = new PhysSettings();
    public InputSettings inputSetting = new InputSettings();

    Vector3 velocity = Vector3.zero;
    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput, jumpInput;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, moveSetting.distToGrounded, moveSetting.ground);
    }

    private void Start()
    {
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();
        else
            Debug.LogError("The Character needs a rigidbody>");

        forwardInput = turnInput = jumpInput = 0;
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis(inputSetting.FORWARD_AXIS); //Interpolated
        turnInput = Input.GetAxis(inputSetting.TURN_AXIS); //Interpolated
        jumpInput = Input.GetAxisRaw(inputSetting.JUMP_AXIS); //Non-Interpolated
    }

    private void Update()
    {
        GetInput();
        Turn();
    }

    private void FixedUpdate()
    {
        Run();
        Jump();

        rBody.velocity = transform.TransformDirection(velocity);
    }

    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputSetting.inputDelay)
        {
            //move
            velocity.z = moveSetting.forwardVel * forwardInput;
        }
        else
        {
            //zero velocity
            velocity.z = 0;
        }
    }

    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputSetting.inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(moveSetting.rotateVel * turnInput * Time.deltaTime, Vector3.up);
        }
        transform.rotation = targetRotation;
    }

    void Jump()
    {
        if (jumpInput > 0 && Grounded())
        {
            // Jump
            velocity.y = moveSetting.jumpVel;
        }
        else if (jumpInput == 0 & Grounded())
        {
            // Zero out the velocity.y
            velocity.y = 0;
        }
        else
        {
            // Decrease velocity.y
            velocity.y -= physSetting.downAccel;
        }
    }
}
