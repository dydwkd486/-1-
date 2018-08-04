using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trans : MonoBehaviour { 
	public Vector3 vector;
	// Use this for initialization
	void Start () {
		 string transz = GameObject.Find("data").GetComponent<Data>().trans;
		Transform asd=GameObject.Find("example").GetComponent<Transform>(); 
		vector.z = -4.0f;
		Debug.Log (transz);
		if (transz.Equals ("303map")) {
			vector.x = -5.17f;
			vector.y= -1.36f;
				asd.transform.position = vector;
				//Vector2(-5.17,-1.36);
		}
		if (transz.Equals ("301map")) {
			vector.x = -15.17f;
			vector.y= -1.36f;
			asd.transform.position = vector;
			//Vector2(-5.17,-1.36);
		}
		if (transz.Equals ("304map")) {
			vector.x = 12.33f;
			vector.y= -1.36f;
			asd.transform.position = vector;
			//Vector2(-5.17,-1.36);
		}
		if (transz.Equals ("307map")) {
			vector.x = 19.83f;
			vector.y= -1.36f;
			asd.transform.position = vector;
			//Vector2(-5.17,-1.36);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
