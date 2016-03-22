using UnityEngine;
using System.Collections;

public class RessurectionScript : MonoBehaviour {

    public AudioClip clip;

    private AudioSource audioSource;
    private Animator anim;
    private GameObject playerOne, playerTwo, storyWall;
    private EventController eventController;
    private bool sceneIsFinished = false;  

    void Awake()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("AudioController");
        audioSource = controller.GetComponent<AudioSource>();
        playerOne = GameObject.FindGameObjectWithTag("B4");
        playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");
        storyWall = GameObject.FindGameObjectWithTag("StoryWall"); 
        //eventController = GameObject.FindGameObjectWithTag("EventController").GetComponent<EventController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "B4")
        {
            Debug.Log("Trigger entered");
            triggerRessurcetionEvent();
        }
    }

    void Update()
    {
        if (sceneIsFinished)
            Destroy(GetComponent<RessurectionScript>());
    }

    public void triggerRessurcetionEvent()
    {
        Debug.Log("EVENT: ressurection event");
        // camera positioning

        // trigger visuals
        StartCoroutine(FadeInWallStory()); 

        // trigger animations

        // trigger sounds 
        audioSource.clip = clip;
        audioSource.Play();

        // handle character controllers
        //playerOne.GetComponent<PlayerController>().enabled = true;
        //playerTwo.GetComponent<PlayerController>().enabled = false;

        // send notification to event handler
        // eventController.handleEvent(ressurectionEvent);
    }

    IEnumerator FadeInWallStory()
    {
        for (float f = 0; f <= 1; f += 0.01f)
        {
            Debug.Log("Fading in wall: ");
            Color c = storyWall.GetComponent<Renderer>().material.color;
            c.a = f;
            storyWall.GetComponent<Renderer>().material.color = c;
            yield return null;
        }

        sceneIsFinished = true;
    }
}
