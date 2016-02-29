using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class SwitchCharacterScript : MonoBehaviour {

	public GameObject characterToSwitchTo;
	public GameObject characterToSwitchFrom;
	private bool switched = false; 

	void Start() {
		characterToSwitchTo.GetComponent<FirstPersonController>().enabled = false;
		characterToSwitchTo.GetComponentInChildren<Camera>().enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("e")){
			if (!switched){
				characterToSwitchTo.GetComponentInChildren<Camera>().enabled = true;
				characterToSwitchTo.GetComponent<FirstPersonController>().enabled = true;
				characterToSwitchFrom.GetComponentInChildren<Camera>().enabled = false;
				characterToSwitchFrom.GetComponent<FirstPersonController>().enabled = false;

				switched = true;
			} else {
				characterToSwitchTo.GetComponentInChildren<Camera>().enabled = false;
				characterToSwitchTo.GetComponent<FirstPersonController>().enabled = false;
				characterToSwitchFrom.GetComponentInChildren<Camera>().enabled = true;
				characterToSwitchFrom.GetComponent<FirstPersonController>().enabled = true;

				switched = false;
			}
		} 
	}
}
