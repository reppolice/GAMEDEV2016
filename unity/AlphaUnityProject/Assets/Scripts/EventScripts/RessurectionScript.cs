using UnityEngine;
using System.Collections;

public class RessurectionScript : MonoBehaviour {

    public AudioClip clip;

    private AudioSource audioSource;
    private Animator anim;
    private GameObject playerOne, playerTwo;
    private EventController eventController; 

    void Awake()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("AudioController");
        audioSource = controller.GetComponent<AudioSource>();
        playerOne = GameObject.FindGameObjectWithTag("PlayerOne");
        playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");
        //eventController = GameObject.FindGameObjectWithTag("EventController").GetComponent<EventController>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        triggerRessurcetionEvent();
    }

    public void triggerRessurcetionEvent()
    {
        Debug.Log("EVENT: ressurection event");
        // camera positioning

        // trigger visuals

        // trigger animations

        // trigger sounds 
        audioSource.clip = clip;
        audioSource.Play();

        // handle character controllers
        playerOne.GetComponent<PlayerController>().enabled = true;
        playerTwo.GetComponent<PlayerController>().enabled = false;

        // send notification to event handler
        // eventController.handleEvent(ressurectionEvent);

        // destroy
        Destroy(GetComponent<RessurectionScript>());
    }
}
