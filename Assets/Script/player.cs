using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class player : MonoBehaviour {
	FirstPersonController firstPersonController;
	GameObject camera;
	// Use this for initialization
	void Start () {
		firstPersonController = GetComponent<FirstPersonController> ();
		camera = transform.FindChild ("FirstPersonCharacter").gameObject;
	}

	// Update is called once per frame
	void Update () {
		firstPersonController.m_WalkSpeed = 5f;
		if(Input.GetKey("c")){
			camera.transform.position += new Vector3 (0f, -1f, 0f);
			firstPersonController.m_WalkSpeed = 2f;

	}
	}
}
