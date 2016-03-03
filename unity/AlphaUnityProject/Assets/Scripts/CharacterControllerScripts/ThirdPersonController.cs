using UnityEngine;
using System.Collections;

public class ThirdPersonController : MonoBehaviour {

    [System.Serializable]
    public class MoveSettings
    {
        public float forwardVelocity = 12.0f;
        public float turnVelocity = 100.0f;
        public float jumpVelocity = 25.0f;
        public float distToGround = 1.0f; // threshold for setting boolean grounded
        public LayerMask ground;
    }

    [System.Serializable]
    public class PhysSettings
    {
        public float downAcceleration = 0.5f;
    }

    [System.Serializable]
    public class InputSettings
    {
        public float inputDelay = 0.1f;
        public string FORWARD_AXIS = "Vertical";
        public string TURN_AXIS = "Horizontal";
        public string JUMP_AXIS = "Jump";
    }

    public MoveSettings moveSetting = new MoveSettings();
    public PhysSettings PhysSetting = new PhysSettings();
    public InputSettings inputSetting = new InputSettings();

    Vector3 velocity = Vector3.zero;
    Quaternion targetRotation;
    Rigidbody rb;
    float forwardInput, turnInput, jumpInput;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    void Start()
    {
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
            rb = GetComponent<Rigidbody>();
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis(inputSetting.FORWARD_AXIS);
        turnInput = Input.GetAxis(inputSetting.TURN_AXIS);
        jumpInput = Input.GetAxisRaw(inputSetting.JUMP_AXIS);
    }

    void Update()
    {
        GetInput();
        Turn();
    }

    void FixedUpdate()
    {
        Run();
        rb.velocity = transform.TransformDirection(velocity);
    }

    void Run()
    {
        
        if (Mathf.Abs(forwardInput) > inputSetting.inputDelay)
        {
            if (inputSetting.FORWARD_AXIS == "RightPadVertical")
            {
                Debug.Log("Normalizing");
                forwardInput *= -1;
            }
                
            velocity.z = moveSetting.forwardVelocity * forwardInput;
        }
        else
            velocity.z = 0;
    }

    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputSetting.inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(moveSetting.turnVelocity * turnInput * Time.deltaTime, Vector3.up);
        }
        transform.rotation = targetRotation;
    }

}
