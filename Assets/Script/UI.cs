using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
	[SerializeField]private Text timer;
	[SerializeField]private Text bulletUI;
	[SerializeField]private Text bulletBoxUI;
	[SerializeField]private Text point;

	float time=90.0f;

	[SerializeField]private GunController gunController;
	[SerializeField]private Target target;

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
		bulletUI.text = "Bullet:" + gunController.Bullet + "/30";
		bulletBoxUI.text = "BulletBox:" + gunController.BulletBox;
		point.text = "Pt:" + target.pt;
	}
}
