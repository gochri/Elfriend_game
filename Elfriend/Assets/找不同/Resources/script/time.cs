using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour {


    public float times;
   
    
    // Use this for initialization
    void Start () {
        times = 0;
    }
	
	// Update is called once per frame
	void Update () {
        times = times + Time.deltaTime;
        //float bit = times / 30;
        //a.transform.localScale = new Vector3(bit+0.02f,1f,0);
        //Vector3 pos = this.transform.position;
        //b.transform.position = new Vector3(bit * 12.1f +pos.x, pos.y, pos.z);

        int a = (int)times;
        int b = a / 60;
        a = a % 60;

        if(b<10&&a<10)
        this.GetComponent<Text>().text = "0"+b.ToString() + ":"+"0"+a.ToString();
        if (10<b  && a < 10)
            this.GetComponent<Text>().text =  b.ToString() + ":" + "0" + a.ToString();
        if (b < 10 && 10<a )
            this.GetComponent<Text>().text = "0" + b.ToString() + ":" +  a.ToString();
        if (b>10&&a>10)
            this.GetComponent<Text>().text = b.ToString() + ":" + a.ToString();
    }
}
