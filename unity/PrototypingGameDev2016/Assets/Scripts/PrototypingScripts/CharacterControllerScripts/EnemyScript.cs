using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public GameObject target;
    NavMeshAgent agent; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.transform.position;
    }

    void Update()
    {
        agent.destination = target.transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
            Destroy(gameObject);
    }
}
