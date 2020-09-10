using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeshow : MonoBehaviour {

	public Text time;
	public Image star1;
	public Image star2;
	public Image star3;
	// Use this for initialization
	void Start () {
		time.text = timer.timeAllstr2show;
		if (timer.score == 1)
		{
			star2.enabled = false;
			star3.enabled = false;
		}
		else if (timer.score == 2) {
			star3.enabled = false;
		}
		else if (timer.score == 3) {
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
