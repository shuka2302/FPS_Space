using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class player : MonoBehaviour {
	FirstPersonController firstPersonController;
	// Use this for initialization
	void Start () {
		firstPersonController = GetComponent<FirstPersonController> ();


	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey("c")){
			transform.localScale = new Vector3 (1f, 1.2f, 1f);
			firstPersonController.m_WalkSpeed = 2f;

	}
		if (Input.GetKeyUp ("c")) {
			transform.localScale = new Vector3 (1f, 1.6f, 1f);
			firstPersonController.m_WalkSpeed = 5f;
		}
}
}
