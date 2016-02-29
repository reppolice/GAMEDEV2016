using UnityEngine;
using System.Collections;

public class CombinePlayers : MonoBehaviour {
    public GameObject bigBall;
    public GameObject smallBall;
    public double spirngEffect; 

    SpringJoint springJoint; 

    void Start()
    {
        springJoint = bigBall.GetComponent<SpringJoint>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("hello");
        }
    }
}
