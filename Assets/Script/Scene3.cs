using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene3 : MonoBehaviour {
	bool a =false;
	public string maptrans= "";
	protected Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		animator.enabled=false;
	}
	
	// Update is called once per frame
	void Update () {
		if (a == true && Input.GetButtonDown ("Fire2")) {
			animator.enabled=true;
			Debug.Log ("합격");
			StartCoroutine(WaitForIt());
			GameObject.Find ("data").GetComponent<Data> ().trans=maptrans;
			Debug.Log ("합격");

		}
	}
	void OnTriggerEnter2D(Collider2D col){
		a = true;
	}
	void OnTriggerExit2D(Collider2D col){
		a = false;
	}
	IEnumerator WaitForIt()
	{
		yield return new WaitForSeconds(0.6f); 
		SceneManager.LoadScene(maptrans);
	}

		
}
