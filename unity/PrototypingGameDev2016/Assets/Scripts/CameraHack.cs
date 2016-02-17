using UnityEngine;
using System.Collections;

public class CameraHack : MonoBehaviour {

    public Transform player; 

    void Update()
    {
        Debug.Log("HackScript: " + transform.position);
        transform.position = player.position;

        float yEulerAngle = player.eulerAngles.y;
        float yRotation = player.rotation.y; 
        Debug.Log("Player eulerY: " + yEulerAngle + ", rotationY: " + yRotation);
        Debug.Log("My eulerY: " + transform.eulerAngles.y);

        transform.rotation = Quaternion.Euler(0.0f, yEulerAngle, 0.0f);
    }
}
