using UnityEngine;
using System.Collections;

public class StickToWall : MonoBehaviour {

    Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (gameObject.GetComponent<FixedJoint>() && !Input.GetButton("StickToWall") && gameObject.GetComponent<FixedJoint>() && !Input.GetKey(KeyCode.V))
        {
            Destroy(gameObject.GetComponent<FixedJoint>());
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Input.GetKey(KeyCode.V))
        {
            Debug.Log("Adding joint");
            FixedJoint joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = collision.rigidbody;
        } else if(gameObject.GetComponent<FixedJoint>())
        {
            Destroy(gameObject.GetComponent<FixedJoint>());
        }
    }
}
