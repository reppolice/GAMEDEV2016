using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    //TODO: Create values for designers
    public CameraTypes type;
    public GameObject player, playerTwo;

    public enum CameraTypes
    {
        THIRD_PERSON_CAMERA,
        SINGLE_PERSON_CAMERA
    }
    
    private ThirdPersonCameraScript thirdPersonCamera;
    private CameraFollow singlePersonCamera;

    void Start()
    {
        thirdPersonCamera = gameObject.AddComponent<ThirdPersonCameraScript>();
        singlePersonCamera = gameObject.AddComponent<CameraFollow>();

        if (!player)
            singlePersonCamera.player = GameObject.FindGameObjectWithTag("B4").transform;
        else
            singlePersonCamera.player = player.transform;

        changeCameraType(type); 
    }

    public void changeCameraType(CameraTypes type)
    {
        Debug.Log("Changing camera type to type: " + type); 
        if(type == CameraTypes.SINGLE_PERSON_CAMERA)
            transitionToSinglePersonCamera(); 
            
        if(type == CameraTypes.THIRD_PERSON_CAMERA)
            transitionToThirdPersonCamera();

   }

    private void transitionToSinglePersonCamera()
    {
        thirdPersonCamera.enabled = false;
        singlePersonCamera.enabled = true;

        // Set variables for camera type 

    }

    private void transitionToThirdPersonCamera()
    {
        Debug.Log("Transistioning to thirdpersoncamera"); 
        thirdPersonCamera.enabled = true;
        singlePersonCamera.enabled = false;

        // Set variables for camera type
    }
}
