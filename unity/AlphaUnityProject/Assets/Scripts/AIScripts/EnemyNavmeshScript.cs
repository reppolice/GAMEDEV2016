using UnityEngine;
using System.Collections;

public class EnemyNavmeshScript : MonoBehaviour {

    //TODO: Find optimal speed
    public float speed = 10.0f; 

    private NavMeshAgent agent;
    private GameObject destination; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    public void MoveToTarget(Vector3 destination)
    {
        agent.destination = destination; 
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        if(collision.gameObject.tag == "B4")
        {
            AttachStickySphere(collision.gameObject); 
        }
    }

    void AttachStickySphere(GameObject target)
    {
        // Adjust sphere behavioural components
        GetComponent<NavMeshAgent>().enabled = false;

        // Child gameObject and collision
        transform.position = target.transform.position + new Vector3(0.0f, 0.5f, 0.0f) + new Vector3(0.0f, 0.0f, 0.2f);
        transform.parent = target.transform;

        // Change material 
        GetComponent<Renderer>().material.color = Color.black;

        // SFX 

        // Edit player speed, and set status 
        target.GetComponent<PlayerController>().speed += -2.0f; 

        // Adjust ambient light  
    }

    public void DetachStickySphere()
    {

    }
}
