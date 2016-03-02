using UnityEngine;
using System.Collections;

public class ThirdPersonCameraScript : MonoBehaviour {

    [SerializeField]
    private float distanceAway;
    [SerializeField]
    private float distanceUp;
    [SerializeField]
    private float smooth;

    private Transform player;
    private Vector3 targetPosition; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        targetPosition = player.position + Vector3.up * distanceUp - player.forward * distanceAway;
        Debug.DrawRay(player.position, Vector3.up * distanceUp, Color.red);
        Debug.DrawRay(player.position, -1f * player.forward * distanceAway, Color.blue );
        Debug.DrawLine(player.position, targetPosition, Color.green);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);

        transform.LookAt(player);
    }

}
