using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AutoTrans3031 : MonoBehaviour {
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
		animator.enabled = false;
		speech2= GameObject.FindGameObjectWithTag ("speech2");
		speech2.SetActive(false);
		speech1= GameObject.FindGameObjectWithTag ("speech1");
		speech1.SetActive(false);
		trans = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		vector.x = 6.82f;
		vector.y = 38.36f;
		vector.z = -10.1f;
		plvector.x = 7.0f;
		plvector.y = 38.66f;
		plvector.z = -2.45f;
		//plvector.y = plvector.y - 3.0f;
		trans.position = plvector;
		a.GetComponent<Camera> ().orthographicSize = 4;
		a.transform.position = vector;
	}

	// Update is called once per frame
	void Update () {
		if (c == 0) {

			StartCoroutine(WaitForIt());

			//c = 2;
		}
	}
	IEnumerator WaitForIt()
	{
		Destroy (GameObject.FindGameObjectWithTag("can"));

		if (d == 0) {
			speech2.SetActive (true);
			yield return new WaitForSeconds (2.0f); 
			speech2.SetActive (false);
		}
		if (d == 0 && trans.position.x < 8.22f) {
			animator.enabled = true;
			animator.SetInteger("Direction", 1);//오른쪽 움직이는 모습
			plvector.x = plvector.x + 0.02f;
			trans.position = plvector;
		} else if (e == 0 && trans.position.y > 36.9f) {
			animator.SetInteger("Direction", 0);//아래쪽
			plvector.y = plvector.y - 0.02f;
			trans.position = plvector;
			d = 2;
		} else if (d == 2 && trans.position.x < 10.0f) {
			animator.SetInteger("Direction", 1);//오른쪽 움직이는 모습
			plvector.x = plvector.x + 0.02f;
			trans.position = plvector;
			e = 1;

		} else if (e == 1) {
			animator.SetInteger("Direction", 2);//위쪽
			yield return new WaitForSeconds (0.3f);
			speech1.SetActive (true);
			yield return new WaitForSeconds (1.0f);
			speech1.SetActive (false);
			d = 3;
		}
		if (e == 1&&d==3 &&trans.position.x > -3.55f) {
			animator.SetInteger("Direction", 3);//왼쪽
			plvector.x = plvector.x - 0.13f;
			trans.position = plvector;
		}


	}
}