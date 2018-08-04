using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkNameChange : MonoBehaviour {

	static Text tex;
	// Use this for initialization
	void Start () {
		tex = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		//이 스크립트는 대사출력부분에서 호출하는 용도로만 사용하기에 Update부분은 사용하지않는다.
	}

	public static void NameChange(string name)
	{
		tex.text = name;
	}
}