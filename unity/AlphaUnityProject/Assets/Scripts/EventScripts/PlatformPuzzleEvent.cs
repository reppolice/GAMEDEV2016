using UnityEngine;
using System.Collections;
//using DG.Tweening;

public class PlatformPuzzleEvent : MonoBehaviour {

    public GameObject switch1, switch2;
    HexagonSwitchScript switchScript1, switchScript2; 
	  
    void Start()
    {
        switchScript1 = switch1.GetComponent<HexagonSwitchScript>();
        switchScript2 = switch2.GetComponent<HexagonSwitchScript>();
    }
    void Update()
    {
        if (switchScript1.getStatus() && switchScript1.getStatus())
        {
            Debug.Log("Both switches are triggered"); 
            triggerEvent(); 
        }
    }
    void triggerEvent()
    {
        // TODO: Move to eventcontroller? 
       // DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
       // gameObject.transform.DOMove(new Vector3(0.0f, 50.0f, 0), 10).SetRelative().SetLoops(1, LoopType.Incremental); 
    }
}
