using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetting : MonoBehaviour {

	static GameObject[] btns = null;
	public static void Create(GameObject prefabButton,string[] names)//복제할 오리지널버튼, 각 버튼들의 이름을 매개변수로 삼아서 버튼을 만들어 배치하는 메소드.
	{
		if (btns != null) Delete(); //이전에 생성해둔 버튼들이 있는경우 먼저 삭제한다.
		GameObject parent = GameObject.FindGameObjectWithTag("UIBackground"); //지정해둔 태그를 가진 오브젝트를 부모 오브젝트로 쓰기위해 가져온다.
		float startheight = Screen.height - Screen.height / 5f; //첫번째 버튼이 생성될 y축 위치
		btns = new GameObject[names.Length]; //버튼 오브젝트 배열 재생성.
		for(int i=0;i<names.Length;i++)//이름의 갯수만큼 반복한다.
		{
			GameObject btn = Instantiate(prefabButton);//prefab 오브젝트를 복제한다.
			RectTransform rect = btn.GetComponent<RectTransform>();//복제한 오브젝트의 recttransform을 가져온다.
			rect.sizeDelta = new Vector2(Screen.width / 5f, Screen.height /20f);//사이즈 조정
			btn.name = "SelectButton" + (i + 1);//오브젝트 이름 지정
			btn.transform.SetParent(parent.transform,false);//가져온 상위오브젝트를 부모오브젝트로 삼되, worldposition을 false로 두어 부모 오브젝트 기준으로 포지션을 정하게 한다.
			btn.transform.position = new Vector2(Screen.width / 2f, startheight - (i*rect.sizeDelta.y)*3f); //버튼간 간격을 적당히 배치.
			btn.GetComponent<Button>().GetComponentInChildren<Text>().text = names[i];//버튼 텍스트 지정.
			btns[i] = btn; //버튼 배열에 현재 생성한 버튼을 담음
		}
	}

	public static void Delete()//생성된 버튼을 모두 제거하는 메소드. 버튼의 클릭이나 버튼이 존재할때 다른 버튼을 다시 생성할경우 발생한다.
	{
		for (int i = 0; i < btns.Length; i++)
			Destroy(btns[i]);//객체를 제거한다.
		btns = null;//버튼 배열을 다시 빈 공간으로 둔다.
	}

}