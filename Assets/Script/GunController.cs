using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
	[SerializeField]private float ct;
	[SerializeField]private ParticleSystem sparkle;
	[SerializeField]private ParticleSystem sparkle2;
	[SerializeField]private AudioClip fire;
	AudioSource audioSource;
	float coolTime=0f;

	[SerializeField]private float Bullet = 30f;
	[SerializeField]private float BulletBox = 150f;
	[SerializeField] private AudioClip reload;

	[SerializeField]private GameObject targetObject;
	Target target;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		target = targetObject.GetComponent<Target> ();
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
					GameObject selectedObj = hit.collider.gameObject;
					if (selectedObj = GameObject.FindGameObjectWithTag ("Target")) {
						target.targetHit ();
					
					}
				}
			}
		}
		if (Bullet < 30f && Input.GetKeyDown ("r")) {
			Reload ();
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
