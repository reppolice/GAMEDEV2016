using UnityEngine;
using System.Collections;

public class GroundPlayerScript : MonoBehaviour {
    public float massWhenGrounded;
    public float defaultMass;
    Rigidbody rb; 

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

	void Update () {
        // TODO: reset velocity
        if (Input.GetKey(KeyCode.F) || Input.GetButton("GroundBall"))
        {
            gameObject.GetComponent<Rigidbody>().mass = massWhenGrounded;
            //rb.velocity = Vector3.zero;
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            rb.angularVelocity = Vector3.zero;
        } else
        {
            gameObject.GetComponent<Rigidbody>().mass = defaultMass;
        }
	}
}
