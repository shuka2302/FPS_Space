using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
	float life=5f;
	Animator anim;
	public float pt=0f;




	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		}

	public void targetHit(){
	life--;
		if(life==0f){
			anim.SetBool("broken",true);
			Invoke ("GetUp", 10f);
		}

	}

	void GetUp (){
		anim.SetBool ("broken", false);
		life = 5f;
	}
	}

