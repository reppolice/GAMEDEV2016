﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public Transform player;
    private Vector3 offset;
    public float smooth = 1.5f;         // The relative speed at which the camera will catch up

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.position;
    }



    void FixedUpdate()
    {
        transform.position = player.position + offset;
    }






}
