using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diffrent : MonoBehaviour {
    public game_main n;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int a = n.NUM/2;
        int b =n.nownum/2;
        this.GetComponent<Text>().text = b.ToString() + "/"+ a.ToString();
    }
}
