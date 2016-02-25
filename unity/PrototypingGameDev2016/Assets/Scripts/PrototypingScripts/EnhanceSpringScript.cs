using UnityEngine;
using System.Collections;

public class EnhanceSpringScript : MonoBehaviour {
    public GameObject bigBall;
    public GameObject smallBall;
    public float springEffect;
    public float defaultSpring; 

    SpringJoint springJoint;

    void Start()
    {
        springJoint = bigBall.GetComponent<SpringJoint>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            springJoint.spring = springEffect;
        } else
        {
            springJoint.spring = defaultSpring;
        }
    }

}
