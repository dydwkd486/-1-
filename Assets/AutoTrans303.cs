using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AutoTrans303 : MonoBehaviour {
	public GameObject a;
	public GameObject speech1;
	public GameObject speech2;
	public Animator animator;
	public Vector3 vector;
	private Transform trans;
	public Vector3 plvector;
	int b=0;
	int c=0;
	int d=0;
	int e =0;
	// Use this for initialization
	void Start () {
		animator =GameObject.Find("Cube").GetComponent<Animator> ();
		animator.enabled = false;;
		speech2= GameObject.FindGameObjectWithTag ("speech2");
		speech2.SetActive(false);
		speech1= GameObject.FindGameObjectWithTag ("speech1");
		speech1.SetActive(false);
		trans = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		vector.x = -2.66f;
		vector.y = 37.56f;
		vector.z = -10.1f;
		a.transform.position = vector;
	}

	// Update is called once per frame
	void Update () {
		if (a.transform.position.y < 50 && b == 0) {
			vector.y = vector.y + 0.12f;
			a.transform.position = vector;
		} else if (a.transform.position.x < 7 && c == 0) {
			vector.x = vector.x + 0.12f;
			a.transform.position = vector;
			b = 1;
		} else if (a.transform.position.y > 40 && b == 1) {
			vector.y = vector.y - 0.12f;
			a.transform.position = vector;
			c = 1;
		} else if (a.transform.position.x > 7 && c == 1) {
			
			StartCoroutine(WaitForIt());

			//c = 2;
	}
}
	IEnumerator WaitForIt()
	{
		Destroy (GameObject.FindGameObjectWithTag("can"));
		yield return new WaitForSeconds(1.0f); 
		if (a.GetComponent<Camera> ().orthographicSize >= 4) {
			a.GetComponent<Camera> ().orthographicSize = a.GetComponent<Camera> ().orthographicSize - 0.02f;
		} else if (d == 0) {
			plvector.x = -2.2f;
			plvector.y = 37.55f;
			plvector.z = -3.5f;
			//plvector.y = plvector.y - 3.0f;
			trans.position = plvector;
			d = 1;
		} else if (d == 1 && trans.position.x < 5.92f) {
			animator.enabled = true;
			animator.SetInteger("Direction", 1);//오른쪽 움직이는 모습
			plvector.x = plvector.x + 0.04f;
			trans.position = plvector;
		} else if (e == 0 && trans.position.y < 38.74f) {
			animator.SetInteger("Direction", 2);//위쪽
			plvector.y = plvector.y + 0.04f;
			trans.position = plvector;
			d = 2;
		} else if (d == 2 && trans.position.x < 7.0f) {
			animator.SetInteger("Direction", 1);//오른쪽 움직이는 모습
			plvector.x = plvector.x + 0.04f;
			trans.position = plvector;
			e = 1;
		} else if (e == 1) {
			animator.SetInteger("Direction", 2);//위쪽
			animator.enabled = false;
			speech1.SetActive (true);
			yield return new WaitForSeconds (3.0f);
			e = 2;
		} else if (e == 2) {
			speech1.SetActive (false);
			yield return new WaitForSeconds (1.0f);
			speech2.SetActive (true);
		}


	}
}