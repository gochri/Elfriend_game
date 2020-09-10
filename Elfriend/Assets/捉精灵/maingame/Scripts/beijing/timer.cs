using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour{
	public static bool startCount =true;
	public Text timetext;
	private float totalTime2;
	public float second2;
	public float min2;
	string s2;
	string m2;
	private string timeAllstr2;
	public static string timeAllstr2show;
	public static int score=0;
	public Text clicknum;


	void Start() {
		totalTime2 = 0;
		second2 = 0;
		min2 = 0;
		StartCount ();
	}
	// Update is called once per frame
	void Update() {
		clicknum.text = string.Format("还需捕捉{0}次",ClickElves1.num);
		if (startCount) {
			Timer2();//正计时
		}
		if (!startCount) {
			if (min2 >= 1)
				score = 1;
			else if (min2 == 0 && second2 < 20)
				score = 3;
			else
				score = 2;
			timeAllstr2show = timeAllstr2;
		}
	}


	private void Timer2()
	{
		//累加每帧消耗时间
		totalTime2 += Time.deltaTime;
		if (totalTime2 >= 1)//每过1秒执行一次
		{
			second2++;
			if (second2 > 59)
			{
				second2 = 0;

				min2++;

				Debug.Log("x过来一秒xx");
			}

			totalTime2 = 0;
		}
		s2 = second2.ToString();
		m2 = min2.ToString();
		if (min2 > 59) {

			min2 = 0;
			second2 = 0;
		}


		if (second2 < 10)
		{

			s2 = string.Format("0{0}", second2);

		}
		if (min2 < 10)
		{
			m2 = string.Format("0{0}", min2);
		}

		timeAllstr2 = string.Format("{0}分{1}秒", m2, s2);
		timetext.text = timeAllstr2;
	}
	public void StartCount()
	{

		startCount = true;
	}

	public void StopCount()
	{   
		startCount = false;
	}
}