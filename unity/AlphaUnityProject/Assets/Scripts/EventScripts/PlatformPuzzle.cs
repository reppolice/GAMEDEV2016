using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PlatformPuzzle : MonoBehaviour {

	   
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            triggerPlatformEvent(); 
        }
    }
    void triggerPlatformEvent()
    {
        // TODO: Move to eventcontroller? 
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
        gameObject.transform.DOMove(new Vector3(0.0f, 50.0f, 0), 10).SetRelative().SetLoops(1, LoopType.Incremental); 
    }
}
