using UnityEngine;
using System.Collections;

public class RopeScript : MonoBehaviour {

    public Transform startPos;
    public Transform endPos;

    Transform firstRopeJoint;
    Transform lastRopeJoint;    

    void Start()
    {
        firstRopeJoint = GameObject.Find("joint1").transform;
        lastRopeJoint = GameObject.Find("joint31").transform; 
    }

    void Update()
    {
        firstRopeJoint.position = startPos.position;
        lastRopeJoint.position = endPos.position;
    }
}
