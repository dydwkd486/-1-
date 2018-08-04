using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {

	int speed=10; //스피드 
	float yMove; 
	void Update () { 
		
		yMove = 0; 

		 
		if (Input.GetKey(KeyCode.UpArrow)) 
			yMove = speed * Time.deltaTime; 
		else if (Input.GetKey(KeyCode.DownArrow)) 
			yMove = -speed * Time.deltaTime; 
		this.transform.Translate(new Vector3(0,yMove,0)); 
	} 
}
