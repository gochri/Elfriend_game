using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeshow2 : MonoBehaviour {

	public Text time;
	public Image star1;
	public Image star2;
	public Image star3;
	// Use this for initialization
	void Start () {
		time.text = timer2.timeAllstr2;
		if (timer2.score2 == 1)
		{
			star2.enabled = false;
			star3.enabled = false;
		}
		else if (timer2.score2 == 2) {
			star3.enabled = false;
		}
		else if (timer2.score2 == 3) {
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
