using UnityEngine;
using System.Collections;

public class EnemyEventScript : MonoBehaviour {
    //TODO: Refactor to list, for better insertion and removal
    GameObject[] enemies;
    GameObject player;
    [HideInInspector]
    public bool chasing; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("B4"); 
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "B4")
            TriggerEnemyEvent();
            
    }

    void FixedUpdate()
    {
        if (chasing)
            UpdateChasePosition(); 

    }

    void UpdateChasePosition()
    {
        for(int i = 0; i<enemies.Length; i++)
        {
            //remove from enemies[]
            if (enemies[i] == null || !enemies[i].GetComponent<NavMeshAgent>().enabled)
                return;
               
            Debug.Log("Editing gameObject navmesh: " + enemies[i].name);
            if (enemies[i].GetComponent<NavMeshAgent>() && player)
            {
                enemies[i].GetComponent<EnemyNavmeshScript>().SetTarget(player); 
            }
        }
    }

    void TriggerEnemyEvent()
    {
        Debug.Log("Event is firing");

        // Play sound 

        // Adjust light

        // Play animations from enemies
        chasing = true; 
    }
}
