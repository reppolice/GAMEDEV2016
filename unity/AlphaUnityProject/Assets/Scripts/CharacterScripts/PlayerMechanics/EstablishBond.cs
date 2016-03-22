﻿using UnityEngine;
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

    private LightScript ls;
    private Light lightSource;

    void Awake()
    {
        playerOne = GameObject.FindGameObjectWithTag("B4");
        playerTwo = GameObject.FindGameObjectWithTag("MiMi");

        gameObject.AddComponent<LightScript>();
        gameObject.AddComponent<Light>(); 
        ls = GetComponent<LightScript>();
        lightSource = GetComponent<Light>(); 
        ls.enabled = false;
        lightSource.enabled = false; 

    }

    void Update()
    {
        if (Input.GetButtonDown("EstablishBond") && !GetComponent<LineRenderer>() && !channelling)
        {
            ls.enabled = true;
            ls.minIntensity = 1;
            ls.maxIntensity = 6;
            ls.pulseSpeed = 2;
            ls.color = Color.white;
            lightSource.enabled = true;
            startTime = Time.time;
            channelling = true;
            
        }
        if (Input.GetButtonUp("EstablishBond"))
        {
            channelling = false;
            lightSource.enabled = false;
            ls.enabled = false; 
            startTime = 0;
        }

        float timeDifference = Time.time - startTime;

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
            Vector3[] points = { playerOne.transform.position + new Vector3(0.0f, 2.0f, 0.0f), playerTwo.transform.position + new Vector3(0.0f, 2.0f, 0.0f) };
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

            // Light
            ls.enabled = false;

            // Updating playerStatusScript 
            // TODO: make it happen on both players 
            gameObject.GetComponent<Light>().enabled = false;
            gameObject.GetComponent<PlayerController>().playerStatus.setBondStatus(true);
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