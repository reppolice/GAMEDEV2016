using UnityEngine;
using System.Collections;


public class LightScript : MonoBehaviour
{
    private Light myLight;
    public float maxIntensity = 8.0f;
    public float minIntensity = 1f;
    public float pulseSpeed = 1f; //here, a value of 0.5f would take 2 seconds and a value of 2f would take half a second
	public Color color; 
	private float targetIntensity = 1f;
    private float currentIntensity;

     
    void Start()
    {
		if (!GetComponent<Light> ()) {
			gameObject.AddComponent<Light> (); 
			myLight = GetComponent<Light>();
			myLight.color = color;  
		} else {
			myLight = GetComponent<Light>();
		}
    }
    void Update()
    {
        currentIntensity = Mathf.MoveTowards(myLight.intensity, targetIntensity, Time.deltaTime * pulseSpeed);
        if (currentIntensity >= maxIntensity)
        {
            currentIntensity = maxIntensity;
            targetIntensity = minIntensity;
        }
        else if (currentIntensity <= minIntensity)
        {
            currentIntensity = minIntensity;
            targetIntensity = maxIntensity;
        }
        myLight.intensity = currentIntensity;
    }
}