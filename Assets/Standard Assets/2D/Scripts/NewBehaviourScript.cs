using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour {
	public bool ac =false;
	public bool b = true;
	public GameObject asd;
	private GameObject zxc;
	// Use this for initialization
	void Awake(){
		bool ac =false;
	}
	void Start () {
		bool ac =false;
	}

	// Update is called once per frame
	void Update () {
		
		if (ac == true && b==true && Input.GetButtonDown ("Fire2")) {
			Debug.Log ("합격");
			Debug.Log (ac);
			Debug.Log (b);
			zxc=Instantiate(asd);
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.transform.tag == "Player") {
			ac = false;
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "Player") {
			ac = true;
		}
	}
}
