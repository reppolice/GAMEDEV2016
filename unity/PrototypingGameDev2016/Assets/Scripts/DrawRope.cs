using UnityEngine;
using System.Collections;
[RequireComponent(typeof(LineRenderer))]


public class DrawRope : MonoBehaviour {

    public Transform smallCubePosition;
    public Transform bigCubePosition;

    private LineRenderer _lineRenderer;

    void Start()
    {
        _lineRenderer = gameObject.GetComponent<LineRenderer>();
    }


    void Update()
    {
        _lineRenderer.SetPosition(0, smallCubePosition.position);
        _lineRenderer.SetPosition(1, bigCubePosition.position);

    }
    


}
