using UnityEngine;
using System.Collections;

public class HexagonSwitchScript : MonoBehaviour {

    public float lightIntensity = 5.0f; 

    private bool on = false;
    private GameObject lightGameObject; 

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerOne" && !on || other.tag == "PlayerTwo" && !on)
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
        if (other.tag == "PlayerOne" && on || other.tag == "PlayerTwo" && on)
        {
            Destroy(lightGameObject);
            on = false;
        }
    }
}
