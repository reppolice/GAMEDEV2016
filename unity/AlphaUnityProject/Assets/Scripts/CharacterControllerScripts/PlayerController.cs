using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 135;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Move(h, v);
    }

    void Move(float h, float v)
    {
        Vector3 movement = new Vector3(h, 0.0f, v);
        rb.AddForce(movement * speed);
    }

}
