using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public float smooth = 1.5f;         // The relative speed at which the camera will catch up

    private Vector3 offset;
    //TODO: Integrate smooth

    void Start()
    {
        offset = transform.position - player.position;
    }



    void FixedUpdate()
    {
        transform.position = player.position + offset;
        Debug.DrawLine(transform.position, player.position); 
    }

    public void changeOffset(float x, float y, float z)
    {
        offset.x += x;
        offset.y += y;
        offset.z += z;
    }
}

