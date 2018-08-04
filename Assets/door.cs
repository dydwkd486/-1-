using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {
	protected Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		animator.enabled=false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2")) {
			animator.enabled=true;
		}
		
	}
}
