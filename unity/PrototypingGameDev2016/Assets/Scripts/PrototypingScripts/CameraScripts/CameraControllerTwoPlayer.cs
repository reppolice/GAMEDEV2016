using UnityEngine;
using System.Collections;

public class CameraControllerTwoPlayer : MonoBehaviour {

    private const float DISTANCE_MARGIN = 15.0f;

    public Transform player1;
    public Transform player2;

    private Vector3 middlePoint;
    private float distanceFromMiddlePoint;
    private float distanceBetweenPlayers;
    private float cameraDistance;
    private float aspectRatio;
    private float fov;
    private float tanFov;

    // Use this for initialization
    void Start()
    {
        aspectRatio = Screen.width / Screen.height;
        tanFov = Mathf.Tan(Mathf.Deg2Rad * Camera.main.fieldOfView / 2.0f);
    }

    // Update is called once per frame
    void Update () {

        // Position the camera in the center.
        Vector3 newCameraPos = Camera.main.transform.position;
        newCameraPos.x = middlePoint.x;
        Camera.main.transform.position = newCameraPos;

        // Find the middle point between players.
        Vector3 vectorBetweenPlayers = player2.position - player1.position;
        vectorBetweenPlayers.y += 4.0f; 
        middlePoint = player1.position + 0.5f * vectorBetweenPlayers;

        // Calculate the new distance.
        distanceBetweenPlayers = vectorBetweenPlayers.magnitude;
        cameraDistance = (distanceBetweenPlayers / 2.0f / aspectRatio) / tanFov;

        // Set camera to new position.
        Vector3 dir = (Camera.main.transform.position - middlePoint).normalized;
        //TODO: Fix this issue
        Camera.main.transform.position = middlePoint + dir * (cameraDistance + DISTANCE_MARGIN);
    }
}
