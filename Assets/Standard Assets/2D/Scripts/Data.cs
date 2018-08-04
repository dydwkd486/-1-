using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {
	public int item303 = 0;
	public string trans = "";
	void Awake(){
		DontDestroyOnLoad (GameObject.FindGameObjectWithTag("data"));
	}

	// Use this for initialization
}
