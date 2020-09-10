using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text_score : MonoBehaviour {


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int a = (int)game_main.time;
        this.GetComponent<Text>().text = a.ToString()+"s";

    }
}
