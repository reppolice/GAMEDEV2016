using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 135;
    public string horizontal;
    public string vertical; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis(horizontal);
        float v = Input.GetAxis(vertical);
        Move(h, v);
    }

    void Move(float h, float v)
    {
        Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);

        if (gameObject.tag == "PlayerTwo")
        {
            v *= -1;
            float deadzone = 0.25f;
            Vector2 stickInput = new Vector2(h, v);
            if (stickInput.magnitude > deadzone)
            {
                movement.x = h;
                movement.z = v;
            }
        } else
        {
            movement = new Vector3(h, 0.0f, v);
        }
      
        rb.AddForce(movement * speed);
    }

}
