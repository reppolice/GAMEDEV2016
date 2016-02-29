using UnityEngine;
using System.Collections;

public class RollScript2 : MonoBehaviour {

    public float inputDelay = 0.1f;
    public float forwardVelocity = 12.0f;
    public float turnVelocity = 100.0f;

    Quaternion targetRotation;
    Rigidbody rb;
    float forwardInput, turnInput; 

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    void Start()
    {
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
            rb = GetComponent<Rigidbody>();
        else
            Debug.LogError("Character have no Rigidbody attached.");

        forwardInput = turnInput = 0; 
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    void Update()
    {
        GetInput();
        Turn(); 
    }

    void FixedUpdate()
    {
        Run();
        //AddForce(); 
        
    }

    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            //move
            rb.velocity = transform.forward * forwardInput * forwardVelocity; 
        }
    }

    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(turnVelocity * turnInput * Time.deltaTime, Vector3.up);
        }
        transform.rotation = targetRotation; 
    }

    void AddForce()
    {
        Debug.Log("Adding force");
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * forwardVelocity);
    }
}
