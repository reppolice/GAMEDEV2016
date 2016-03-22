using UnityEngine;
using System.Collections;

public class HexagonSwitchScript : MonoBehaviour {

    public float lightIntensity = 5.0f;
    public PlatformPuzzleEvent puzzleEvent; 
    private bool isActive = false;
    private GameObject lightGameObject; 

    void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<PlayerController>().playerStatus.getBondStatus())
        {
            return; 
        }

        if (other.tag == "B4" && !isActive || other.tag == "MiMi" && !isActive)
        {
            lightGameObject = new GameObject("The Light");
            lightGameObject.AddComponent<Light>(); 
            Light light = lightGameObject.GetComponent<Light>();
            light.transform.position = transform.position + Vector3.up; 
            light.intensity = lightIntensity;
            isActive = true;

            // trigger canChannel: 
            other.GetComponent<PlayerController>().playerStatus.setChannelStatus(true); 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "B4" && isActive || other.tag == "MiMi" && isActive)
        {
            Destroy(lightGameObject);
            isActive = false;
            other.GetComponent<PlayerController>().playerStatus.setChannelStatus(false);
        }
    }

    public bool getStatus()
    {
        return isActive; 
    }
}
