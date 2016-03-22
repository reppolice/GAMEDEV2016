using UnityEngine;
using System.Collections;

public class EventController : MonoBehaviour {

    //TODO: Make checkboxes for events, layering each event
    //RESSOURCE: 
    // - https://www.youtube.com/watch?v=jQgwEsJISy0
    private RessurectionScript ressurectionEvent;
    private GameObject playerOne, playerTwo; 

    


    void Awake()
    {
        playerOne = GameObject.FindGameObjectWithTag("PlayerOne");
        playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");
    }
}
