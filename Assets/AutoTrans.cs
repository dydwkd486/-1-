using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AutoTrans : MonoBehaviour {
	public GameObject a;
	public Vector3 vector;
	// Use this for initialization
	void Start () {
		vector.x = -20.76f;
		vector.y = -0.08f;
		vector.z = -14.09f;
	}
	
	// Update is called once per frame
	void Update () {
		vector.x=vector.x+0.12f;
		a.transform.position = vector;

		if (a.transform.position.x > 22) {
			Debug.Log ("화면 넘ㅣ자");
			SceneManager.LoadScene("301mapstory");
		}
	}
}
