using UnityEngine;
using System.Collections;

public class RopeScript : MonoBehaviour {

    public Transform startPos;
    public Transform endPos;

    Transform firstRopeJoint;   

    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(0, 10, 0);
    }
}
