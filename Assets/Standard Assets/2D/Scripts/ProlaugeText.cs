using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ProlaugeText : MonoBehaviour {
	//public AudioClip typingsound; //인스펙터에서 지정할 효과음
	public Canvas asd;
	List<string> texs = new List<string>(); //스크립트 받을 동적배열
	private Text tex; //텍스트 컴포넌트
	//AudioSource au;//오디오 컴포넌트
	int cnt = 0; //몇번째 스크립트인지 받을 int 변수
	// Use this for initialization
	void Start () {
		tex = GetComponent<Text>();
		//au = GetComponent<AudioSource>();
		//스크립트의 저장은 나중에 따로 생각해봐야겠지만, 일단은 임의로 3줄을 생각해서 넣었다.
		texs.Add("너부리:첫번째 대본입니다");
		texs.Add("포로리:두번째 스크립트입니다");
		texs.Add("보노보노:세번째 보노보노입니다");
		texs.Add("보노보노:세번째 보노보노입니다");
		tex.text = ""; //문자를 기존에 있던 문자열에 추가하는 방식이므로 처음에는 문자열이 없게 한다.
		StartCoroutine("Printing"); //코루틴 실행
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)) //엔터키를 누른경우
		{
			Debug.Log("엔터키가 입력되었습니다");
			StopCoroutine("Printing"); //실행중이던 코루틴 중지
			//au.Stop(); //실행되던 효과음 중지
			tex.text = ""; //다음 스크립트 출력을 위해 문자열 초기화
			cnt++; //다음 index를 읽기 위해 index 상승.
			if (cnt > 2) {
				cnt = 0;
				asd.gameObject.SetActive (false);
			} //전체 스크립트가 현재 3개뿐이므로 3개를 넘은경우 다시 처음 문자열을 읽도록 한다.
			StartCoroutine("Printing"); //코루틴 재실행
		}
	}

	IEnumerator Printing()
	{
		int colindex = texs[cnt].IndexOf(":"); // ":"의 인덱스를 가져온다.
		string name = texs[cnt].Substring(0, colindex);//가져온 인덱스 이전까지의 문자열을 받는다.
		Debug.Log(name);
		TalkNameChange.NameChange(name); //받은 문자열로  TalkNameChange의 메소드 실행
		for (int j = colindex+1; j < texs[cnt].Length; j++) // ":"의 인덱스 다음 부분부터 스크립트의 마지막부분까지 for문 실행
		{
			tex.text += texs[cnt][j];//현재 문자열에 해당 index의 문자를 추가한다.
			//if (!au.isPlaying) au.PlayOneShot(typingsound, 0.1f);//효과음이 미재생인 상태에서 타이핑되는경우 타이핑 효과음 출력
			yield return new WaitForSeconds(0.01f);//다음 글자 출력까지 0.1초 동안 대기
		}
		yield return new WaitForSeconds(1f);//효과음 delay를 위해 1초동안 대기
		//au.Stop();//효과음 정지
		StopCoroutine("Printing");//코루틴 정지. 이 상태에서 enter가 들어올때까지 문자열은 변하지 않는다.
	}
}
