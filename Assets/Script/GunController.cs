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

	float Bullet = 30f;
	float BulletBox = 150f;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		coolTime += Time.deltaTime;

		if (Input.GetMouseButtonDown (0) && BulletBox > 0f) {
			if (coolTime > ct) {
				coolTime = 0f;

				Bullet--;
				if (Bullet == 0f) {
					BulletBox--;
					Bullet = 30f;
				}

				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit = new RaycastHit ();

				if (Physics.Raycast (ray, out hit)) {
					sparkle.Emit (1);
					sparkle2.transform.position = hit.point;
					sparkle2.Emit (1);
					audioSource.PlayOneShot (fire);

				}
			}
		}
	}
}
