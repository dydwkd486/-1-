using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {
	private Animator animator;
	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
	}
	int speed=10; //스피드 
	float xMove,yMove; 
	void Update () { 
		xMove = 0; 
		yMove = 0; 
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			xMove = speed * Time.deltaTime; 
			animator.SetInteger("Direction", 1);//오른쪽

		} else if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			xMove = -speed * Time.deltaTime; 
			animator.SetInteger("Direction", 3);//왼쪽
		}
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			yMove = speed * Time.deltaTime; 
			animator.SetInteger("Direction", 2);//위쪽
		} else if (Input.GetKey (KeyCode.DownArrow)) 
		{
			
			yMove = -speed * Time.deltaTime;
			animator.SetInteger("Direction", 0);//아래쪽
		}
		this.transform.Translate(new Vector3(xMove,yMove,0)); 
	} 


}
