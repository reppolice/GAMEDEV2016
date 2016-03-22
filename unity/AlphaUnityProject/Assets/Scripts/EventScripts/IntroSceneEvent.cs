using UnityEngine;
using System.Collections;

public class IntroSceneEvent : MonoBehaviour {

    private GameObject B4; 
    void Start()
    {
        B4 = GameObject.FindGameObjectWithTag("PlayerOne");
        B4.GetComponent<PlayerController>().enabled = false;
        StartCoroutine(ZoomOutCamera(1.0f, 10.0f)); 
        //StartCoroutine(StartScene(2.0f));
    }

    IEnumerator ZoomOutCamera(float time, float zoomAmount)
    {
        for (float f = time; f >= 0; f -= 0.1f)
        {
            Debug.Log("ZoomOutCamera triggered: with params, time: " + f + ", zoomAmount: " + zoomAmount);
            Camera.main.GetComponent<CameraFollow>().changeOffset(0.0f, 0.005f, -0.05f);
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator StartScene(float time)
    {
        yield return new WaitForSeconds(2.0f);
        print("WaitAndPrint " + Time.time);
        B4.GetComponent<PlayerController>().enabled = true;
    }
}
