using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {
	public Transform asd;
	private Animator anim;
	private float h;
	private Rigidbody2D rig2d;
	public float moveForce = 50f;
	public float maxSpeed = 2f;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rig2d = GetComponent<Rigidbody2D> ();
		asd = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		h = Input.GetAxis ("Horizontal");
	}
	void FixedUpdate ()
	{
		if (h < 0) {

			asd.localScale=new Vector3(0.6f,0.6f,1.0f);
			anim.SetFloat ("Speed", -h);
		}
		if (h > 0) {
			asd.localScale=new Vector3(-0.6f,0.6f,1.0f);
			anim.SetFloat ("Speed", h);

		}
		//anim.SetFloat ("Speed", h);
		if (h * rig2d.velocity.x < maxSpeed) {
			rig2d.AddForce (Vector2.right * h * moveForce);
		}
	}
}
