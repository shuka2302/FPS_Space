using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("c")){
			transform.position += new Vector3 (0f, -1f, 0f);
			if (Input.GetKey ("up")) {
				transform.position += new Vector3 (0.001f, 0f, 0f)*Time.deltaTime;
			}
			if (Input.GetKey ("down")) {
				transform.position += new Vector3 (-0.001f, 0f, 0f)*Time.deltaTime;
			}
			if (Input.GetKey ("right")) {
				transform.position += new Vector3 (0f, 0.001f, 0f)*Time.deltaTime;
			}
			if (Input.GetKey ("left")) {
				transform.position += new Vector3 (0f, -0.001f, 0f)*Time.deltaTime;
			}


	}
}
}
