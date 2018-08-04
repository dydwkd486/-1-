using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene1 : MonoBehaviour {
	bool a =false;
	public string maptrans= "";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (a == true && Input.GetButtonDown ("Fire2")) {
			GameObject.Find ("data").GetComponent<Data> ().trans=maptrans;
			Debug.Log ("합격");
			SceneManager.LoadScene(maptrans);
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		a = true;
	}
	void OnTriggerExit2D(Collider2D col){
		a = false;
	}

}
