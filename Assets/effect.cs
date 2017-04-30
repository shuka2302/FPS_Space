using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour {
	public ParticleSystem sparkle;
	public ParticleSystem sparkle2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit ();

			if (Physics.Raycast (ray, out hit)) {
				sparkle.Emit(1);
				sparkle2.transform.position = hit.point;
				sparkle2.Emit (1);
			}
		}
	}
}
