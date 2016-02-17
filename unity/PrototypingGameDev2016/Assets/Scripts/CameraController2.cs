using UnityEngine;
using System.Collections;

public class CameraController2 : MonoBehaviour {

    public Transform target;
    public float lookSmooth = 0.09f;
    public Vector3 offsetFromTarget = new Vector3(0, 6, -8); 
    public float xTilt = 10;

    Vector3 destination = Vector3.zero;
    RollScript2 charController;
    float rotateVel = 0.0f; 

    void Start()
    {
        SetCameraTarget(target);
    }

    public void SetCameraTarget(Transform t)
    {
        if (target != null)
        {
            if (target.GetComponent<RollScript2>())
            {
                charController = target.GetComponent<RollScript2>(); 
            }
            else
                Debug.Log("Target needs a character Controller.");
            target = t;
        } else {
            Debug.Log("Your camera needs a target.");
        }
        
    }

    // Try experiment with other updates
    void LateUpdate()
    {
        // move
        MoveToTarget();
        // Rotate
        LookAtTarget();
    }

    void MoveToTarget()
    {
        destination = charController.TargetRotation * offsetFromTarget;
        destination += target.position;
        transform.position = destination;  
    }

    void LookAtTarget()
    {
        // TODO: Clamp angles
        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);
    }
	
}
