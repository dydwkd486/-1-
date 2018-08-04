using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class a303호시체 : MonoBehaviour {

	//public AudioClip typingsound;
	public GameObject asd;
	public GameObject zxc;
	public string txtname = "example";//로드할 대본 이름,일단은 1오브젝트= 1대본이라 생각하고, 인스펙터에서 직접 지정한다.
	public float delay = 0.1f; //글자 한글자 출력 사이 간격. 초기값은 0.1초
	public GameObject prefabButton; //복제할 버튼 오브젝트
	Text script; //대사 출력 텍스트
	//AudioSource au;
	List<string> scripts; //현재 대사 모음집.
	int a=0;
	int cnt = 0; //현재 대사집에서 몇번째 대사인지 판정.
	int selnum = 0; //선택지에서 몇번째 선택지를 골랐는지 판정.
	// Use this for initialization
	void Start () {
		script = GetComponent<Text>();//텍스트 컴포넌트 가져옴.
		//au = GetComponent<AudioSource>();//오디오소스 컴포넌트 가져옴
		script.alignment = TextAnchor.MiddleLeft;//텍스트의 기본 정렬을 가운데-왼쪽 정렬로
		ScriptRefresh(txtname);//대사집 재정렬.
		zxc =GameObject.FindGameObjectWithTag("시체");
	}

	// Update is called once per frame
	void Update () {
		selnum = SelectNum.Select; //선택한 숫자를 가져옴 (선택지 미출현시 0으로 고정)
		if (selnum != 0) //선택한 숫자가 0이 아닌경우(선택지가 선택된 경우)
		{
			ScriptRefresh(txtname + "-" + selnum);//선택한 숫자에 대해 대사집을 불러와 새로 고침.
			selnum = 0; //중복선택되지 않도록 선택한 숫자를 다시 0으로 둠.
		}
		if (Input.GetKeyDown(KeyCode.Return)) //엔터키를 누른경우
		{
			StopCoroutine("Printing"); //실행중이던 코루틴 중지
			//au.Stop(); //실행되던 효과음 중지
			if (cnt == scripts.Count - 1) {//스크립트의 끝에 도달한경우
				Debug.Log(":"+cnt);
				Debug.Log(scripts.Count - 1);
				ButtonSetting.Create (prefabButton, new string[] { "범인은 301호다", "범인은 304호다","범인은 307호다" });//버튼 생성.
				a++;
			}
			if (cnt == scripts.Count - 1&& a==2) {//스크립트의 끝에 도달한경우
				Debug.Log("여기서 삭제");
				Destroy (asd);
				Destroy (zxc);
				GameObject.Find ("data").GetComponent<Data> ().item303++;

			}
			else
			{
				cnt++; //다음 index를 읽기 위해 index 상승.
				Debug.Log(cnt);
				StartCoroutine("Printing"); //코루틴 재실행
			}
		}

	}
	IEnumerator Printing()
	{
		script.text = ""; //다음 스크립트 출력 이전에 기존에 있던 내용을 지움.
		int colindex = scripts[cnt].IndexOf(":"); // ":"의 인덱스를 가져온다.
		string name = scripts[cnt].Substring(0, colindex);
		//NameChanger.Name = name;
		TalkNameChange.NameChange(name);
		for (int j = colindex + 1; j < scripts[cnt].Length; j++) // ":"의 인덱스 다음 부분부터 스크립트의 마지막부분까지 for문 실행
		{
			script.text += scripts[cnt][j];//현재 문자열에 해당 index의 문자를 추가한다.
			//if (!au.isPlaying) au.PlayOneShot(typingsound, 0.1f);//효과음이 미재생인 상태에서 타이핑되는경우 타이핑 효과음 출력
			yield return new WaitForSeconds(0.1f);//다음 글자 출력까지 0.1초 동안 대기
		}
		yield return new WaitForSeconds(1f);//효과음 delay를 위해 1초동안 대기
		//au.Stop();//효과음 정지
		StopCoroutine("Printing");//코루틴 정지. 이 상태에서 enter가 들어올때까지 문자열은 변하지 않는다.
	}

	void ScriptRefresh(string textfilename) //텍스트파일의 내용을 불러와 대사집에 채우는 메소드
	{
		scripts = new List<string>();//대사집 초기화
		TextAsset file = Resources.Load(textfilename) as TextAsset; //TextAsset의 형태로 텍스트파일을 불러옴
		Debug.Log (file);
		StringReader reader = new StringReader(file.text); //해당 텍스트파일을 string으로 가져옴,
		while (true)//while문 내부에서 break조건이 있으므로 기본적으로 true로 설정.
		{
			string line = reader.ReadLine();//한줄 읽음.
			if (line == null) break;//읽은 문자열이 없는경우 종료
			scripts.Add(line);//대사집에 해당 대사 추가.
		}
		cnt = 0;//대사집의 처음부터 다시 읽어야하므로 카운트를 다시 0으로 둔다.
		StartCoroutine("Printing"); //코루틴 재실행
	}
}
