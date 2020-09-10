using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickElves1 : MonoBehaviour
{
	public static int num=10;//计数
    void OnMouseUp()
    {

		num--;
		if (num == 0) {
			timer.startCount = false;
			SceneManager.LoadScene ("searchwin1");
			num = 10;
		}
    }

}
