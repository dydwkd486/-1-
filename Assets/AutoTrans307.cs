using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AutoTrans307 : MonoBehaviour {
	public GameObject a;
	public Vector3 vector;
	int b=0;
	// Use this for initialization
	void Start () {
		vector.x = -2.66f;
		vector.y = 37.56f;
		vector.z = -10.1f;
	}

	// Update is called once per frame
	void Update () {

		if (a.transform.position.y < 50&&b==0) {
			vector.y = vector.y + 0.12f;
			a.transform.position = vector;
		}
		else if (a.transform.position.x < 7) {
			vector.x = vector.x + 0.12f;
			a.transform.position = vector;
			b = 1;
		}
		else if (a.transform.position.y > 35&&b==1) {
			vector.y = vector.y - 0.12f;
			a.transform.position = vector;
		}
		else if (a.transform.position.x > 7) {
			Debug.Log ("화면 넘ㅣ자");
			SceneManager.LoadScene("303mapstory");
		}
	}
}
