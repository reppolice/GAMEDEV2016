using UnityEngine;
using System.Collections;

public class CombinePlayersScript : MonoBehaviour {
    public GameObject smallBall;
    bool isCarrying = false; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isCarrying)
        {
            CombineBalls();
        } else if(Input.GetKeyDown(KeyCode.Q) && isCarrying)
        {
            DetachBalls();
        }

        if (isCarrying)
        {
            CombineBalls();
        }
    }

    void CombineBalls()
    {
        Vector3 offset = new Vector3(0.0f, 1.5f, 0.0f);
        smallBall.GetComponent<Rigidbody>().isKinematic = true;
        smallBall.transform.position = transform.position + offset;
        isCarrying = true; 
    }
    
    void DetachBalls()
    {
        isCarrying = false;
        smallBall.GetComponent<Rigidbody>().isKinematic = false;
    }
}
