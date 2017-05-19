using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class GunController : MonoBehaviour {
	[SerializeField]private float ct;
	[SerializeField]private ParticleSystem sparkle;
	[SerializeField]private ParticleSystem sparkle2;
	[SerializeField]private AudioClip fire;
	AudioSource audioSource;
	float coolTime=0f;

	public float Bullet = 30f;
	public float BulletBox = 150f;
	[SerializeField] private AudioClip reload;

	GameObject selectedObj;
	[SerializeField]private GameObject target;
	Target targetS;
	[SerializeField]private GameObject HeadMarker;

	//[SerializeField]private DepthOfField depth;
	[SerializeField]private Image snipe;


	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		targetS = target.GetComponent<Target> ();

		snipe.enabled = false;
		//depth.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		coolTime += Time.deltaTime;

		if (Input.GetMouseButtonDown (0) && Bullet > 0f) {
			if (coolTime > ct) {
				coolTime = 0f;

				Bullet--;

				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit = new RaycastHit ();

				if (Physics.Raycast (ray, out hit)) {
					sparkle.Emit (1);
					sparkle2.transform.position = hit.point;
					sparkle2.Emit (1);
					audioSource.PlayOneShot (fire);

					selectedObj = hit.collider.gameObject;
					Vector3 hitPoint = hit.point;
					Vector3 marker = HeadMarker.transform.position;
					float dis = Vector3.Distance (hitPoint, marker);
					if (selectedObj.tag=="Target") {
						targetS.targetHit ();
						if (dis<=0.2f) {
							targetS.pt += 30f;
						} else if (dis <= 0.7f) {
							targetS.pt += 20f;
						} else {
							targetS.pt += 10f;
						}
					}
						
							
				}
			}
		}
		if (Bullet < 30f && Input.GetKeyDown ("r")) {
			Reload ();
		}

		if (Input.GetMouseButtonDown (1)) {
			if (snipe.enabled == false) {
				Camera.main.fieldOfView = 45;
				snipe.enabled = true;
			} else {
				Camera.main.fieldOfView = 60;
				snipe.enabled = false;
			}
		}

	}

	void Reload(){
		float BulletR = 30f - Bullet;
		if (BulletBox > 0f) {
			audioSource.PlayOneShot (reload);
			if (BulletR <= BulletBox) {
				Bullet = 30f;
				BulletBox -= BulletR;
			} else if (BulletR > BulletBox) {
				Bullet += BulletBox;
				BulletBox = 0f;
			}
		}
	}



}
