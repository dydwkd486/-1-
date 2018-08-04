using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectNum : MonoBehaviour {

	private static int Selnum;
	public static int Select //실제로 외부 코드에서 사용하는 부분
	{
		get
		{
			int ret = Selnum;//리턴할값 지정
			Selnum = 0; //한번 호출된 뒤로는 다시 0이 된다.
			return ret;//리턴.
		}
		set
		{
			if (value != 0) Selnum = value; //0이 아닌경우(get에서 다시 set되는거 방지)에만 value를 받아들임.
		}
	}
}