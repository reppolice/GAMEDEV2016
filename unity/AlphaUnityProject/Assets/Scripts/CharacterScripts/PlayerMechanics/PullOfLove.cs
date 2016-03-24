using UnityEngine;
using System.Collections;

public class PullOfLove : MonoBehaviour {
    GameObject B4, MiMi;
    PlayerStatusScript B4Status, MiMiStatus;

    // Time variables for not spamming pull of love 
    public float timeDelay = 0.5f;
    public float pullEffect = 100.0f; 
    float startTime = 0.0f;

    // Debugging information: 
    Vector3 middlePosition; 

	void Start () {
        B4 = GameObject.FindGameObjectWithTag("B4");
        MiMi = GameObject.FindGameObjectWithTag("MiMi");
        B4Status = B4.GetComponent<PlayerController>().playerStatus;
        MiMiStatus = MiMi.GetComponent<PlayerController>().playerStatus;
    }

    void Update()
    {


        


        // This needs to be set here, but ideally needs to happen in another function. 
        // This is caused since playerStatusScript is created in the Start of another function i think 
        // TODO: Fix it
        B4Status = B4.GetComponent<PlayerController>().playerStatus;
        MiMiStatus = MiMi.GetComponent<PlayerController>().playerStatus;

        // Makes sure we can't spam the button
        if (Input.GetKey(KeyCode.R))
        {
            MiMi.transform.LookAt(transform.position);
        }
        if(B4Status.getBondStatus() && Input.GetKey(KeyCode.T))
        {
            float timeDifference = Time.time - startTime;
            if (timeDifference > timeDelay)
            {
                startTime = Time.time;
                PullPlayer();
            }
        }
    }

    void PullPlayer()
    {
        if (gameObject.tag == "B4")
        {
            middlePosition = (MiMi.transform.position + transform.position) / 2.0f;
            Debug.DrawLine(transform.position, middlePosition, Color.white);
            Vector3 forceVector = middlePosition - MiMi.transform.position; 
            Debug.Log("Adding force with vec3: " + forceVector);
            MiMi.GetComponent<Rigidbody>().AddForce(forceVector * pullEffect);
        }
    }
}
