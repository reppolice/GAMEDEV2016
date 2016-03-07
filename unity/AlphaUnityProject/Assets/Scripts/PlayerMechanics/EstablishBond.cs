using UnityEngine;
using System.Collections;

public class EstablishBond : MonoBehaviour {

    //TODO: Consider if category values should be in a class... 
    [SerializeField]
    public float bondWidthBegin = 0.2f;

    [SerializeField]
    public float bondWidthEnd = 0.4f;

    [SerializeField]
    public float damper = 0.1f;

    [SerializeField]
    public float maxSpringDistance = 10.0f;

    private GameObject playerOne;
    private GameObject playerTwo;

    private bool bondEstablished, channelling = false;
    private float startTime = 0.0f; 

    void Awake()
    {
        playerOne = GameObject.FindGameObjectWithTag("PlayerOne");
        playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");
    }

    void Update()
    {
        if (Input.GetButtonDown("EstablishBond") && !GetComponent<LineRenderer>() && !channelling)
        {

            startTime = Time.time;
            channelling = true;
            
        }
        if (Input.GetButtonUp("EstablishBond"))
        {
            channelling = false;
            startTime = 0; 
        }

        float timeDifference = Time.time - startTime;

        //Debug.Log("StartTime: " + startTime);
        //Debug.Log("TimeTime: " + Time.time);
        //Debug.Log("SecondsPassed: " + timeDifference);

        if (timeDifference > 2.0f && timeDifference < 2.2f && channelling)
        {
            CreateBond();
            channelling = false; 
        }

        if (bondEstablished && GetComponent<LineRenderer>())
        {
            UpdateBond(); 
        }

        if(Input.GetKey(KeyCode.Q) && GetComponent<LineRenderer>())
        {
            DestroyBond(); 
        }
    }

    void CreateBond()
    {
        if (!gameObject.GetComponent<LineRenderer>())
        {
            // Visuals: 
            gameObject.AddComponent<LineRenderer>();
            LineRenderer lr = GetComponent<LineRenderer>();
            lr.SetWidth(bondWidthBegin, bondWidthEnd);
            Vector3[] points = { playerOne.transform.position, playerTwo.transform.position };
            lr.SetPositions(points);
            bondEstablished = true;

            // Springjoint: 
            gameObject.AddComponent<SpringJoint>();
            SpringJoint joint = GetComponent<SpringJoint>();
            joint.connectedBody = playerTwo.GetComponent<Rigidbody>(); 
            joint.maxDistance = maxSpringDistance;
            joint.damper = damper;
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = new Vector3(-4, 0, 0);  
        }
    }

    void UpdateBond()
    {
        LineRenderer lr = gameObject.GetComponent<LineRenderer>();
        Vector3[] points = { playerOne.transform.position, playerTwo.transform.position };
        lr.SetPositions(points);
    } 

    void DestroyBond()
    {
        Destroy(gameObject.GetComponent<LineRenderer>());
        Destroy(gameObject.GetComponent<SpringJoint>()); 
    }
}
