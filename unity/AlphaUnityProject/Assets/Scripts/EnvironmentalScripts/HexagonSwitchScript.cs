using UnityEngine;
using System.Collections;

public class HexagonSwitchScript : MonoBehaviour {

    public float lightIntensity = 5.0f; 

    private bool on = false;
    private GameObject lightGameObject; 

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "B4" && !on || other.tag == "MiMi" && !on)
        {
            lightGameObject = new GameObject("The Light");
            lightGameObject.AddComponent<Light>(); 
            Light light = lightGameObject.GetComponent<Light>();
            light.transform.position = transform.position + Vector3.up; 
            light.intensity = lightIntensity;
            on = true; 
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "B4" && on || other.tag == "MiMi" && on)
        {
            Destroy(lightGameObject);
            on = false;
        }
    }
}
