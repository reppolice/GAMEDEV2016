using UnityEngine;
using System.Collections;

public class EventController : MonoBehaviour {
    
    private RessurectionScript ressurectionEvent;
    private GameObject playerOne, playerTwo; 


    void Awake()
    {
        playerOne = GameObject.FindGameObjectWithTag("PlayerOne");
        playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");
    }


}
