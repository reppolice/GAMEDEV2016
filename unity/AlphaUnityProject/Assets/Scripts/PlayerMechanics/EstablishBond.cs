using UnityEngine;
using System.Collections;

public class EstablishBond : MonoBehaviour {

    [SerializeField]
    public float bondWidthBegin = 0.2f;

    [SerializeField]
    public float bondWidthEnd = 0.4f;

    GameObject playerOne;
    GameObject playerTwo;
    bool bondEstablished, channeling = false;
    float startTime = 0.0f; 

    void Awake()
    {
        playerOne = GameObject.FindGameObjectWithTag("PlayerOne");
        playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");
    }

    void Update()
    {
        if (Input.GetButtonDown("EstablishBond") && !GetComponent<LineRenderer>() && !channeling)
        {

            startTime = Time.time;
            channeling = true;
            CreateBond();
        }

        if (Input.GetButtonDown("EstablishBond"))
        {
            if(Time.time - startTime > 3.0f && channeling)
            {
                CreateBond();
            }
        }

        if (Input.GetButtonUp("EstablishBond"))
        {
            startTime = 0.0f;
            channeling = false; 
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
        gameObject.AddComponent<LineRenderer>();
        LineRenderer lr = gameObject.GetComponent<LineRenderer>();
        lr.SetWidth(bondWidthBegin, bondWidthEnd);
        Vector3[] points = { playerOne.transform.position, playerTwo.transform.position };
        lr.SetPositions(points);
        bondEstablished = true; 
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
    }
}
