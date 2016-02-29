using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    void Start() {
        offset = transform.position - player.transform.position; 
    }

    void LateUpdate(){
        transform.position = player.transform.position + offset;
        Quaternion angle = transform.rotation;
        Quaternion playerAngle = player.transform.rotation;
        angle.y = playerAngle.y;

        //transform.RotateAround(player.transform.position, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * speedMod);

    }
}
