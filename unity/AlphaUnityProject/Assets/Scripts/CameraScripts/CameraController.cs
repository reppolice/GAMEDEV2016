using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    //TODO: Create values for designers
    public GameObject player, playerTwo; 

    private ThirdPersonCameraScript thirdPersonCamera;
    private CameraFollow singlePersonCamera;

    public enum CameraTypes {
        THIRD_PERSON_CAMERA, 
        SINGLE_PERSON_CAMERA
    }

    void Start()
    {
        thirdPersonCamera = gameObject.AddComponent<ThirdPersonCameraScript>();
        singlePersonCamera = gameObject.AddComponent<CameraFollow>();

        // Testing and hardcoded: 
        gameObject.GetComponent<ThirdPersonCameraScript>().enabled = false;

        if (!player)
            singlePersonCamera.player = GameObject.FindGameObjectWithTag("PlayerTwo").transform;
        else
            singlePersonCamera.player = player.transform; 
    }

    public void changeCameraType(CameraTypes type)
    {
        if(type == CameraTypes.SINGLE_PERSON_CAMERA)
            transitionToSinglePersonCamera(); 
            
        if(type == CameraTypes.THIRD_PERSON_CAMERA)
            transitionToSinglePersonCamera();

   }

    private void transitionToSinglePersonCamera()
    {
        thirdPersonCamera.enabled = false;
        singlePersonCamera.enabled = true;

        // Set variables for camera type 

    }

    private void transitionToThirdPersonCamera()
    {
        thirdPersonCamera.enabled = true;
        singlePersonCamera.enabled = false;

        // Set variables for camera type
    }
}
