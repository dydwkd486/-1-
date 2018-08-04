using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item303 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("data").GetComponent<Data> ().item303 == 1) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
