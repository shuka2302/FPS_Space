using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
	[SerializeField]private Text timer;
	float time=90.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time < 0) {
			time = 0f;
		}
		timer.text = "Time:" + time.ToString ("F1") + "s";
	}
}
