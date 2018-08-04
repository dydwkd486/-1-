using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour {
	public void Click()
	{
		Button btn = GetComponent<Button>(); //현재 객체를 가져온다.

		SelectNum.Select = Convert.ToInt32(Regex.Replace(btn.name, @"\D", ""));//객체의 이름에서 숫자만 남긴걸 int변환해 현재 선택된 선택지 번호로서 삼는다.
		ButtonSetting.Delete();//현재 표시되있는 버튼 객체들을 모두 제거한다.
	}
}