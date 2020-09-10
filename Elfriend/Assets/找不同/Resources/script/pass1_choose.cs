using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pass1_choose : MonoBehaviour {


    public int ID;
    public int state;
    public Sprite[] images;

    public  data maxpass;

	// Use this for initialization
	void Start () {
        state = 0;
	}

   

    // Update is called once per frame
    void Update () {

        if (ID <= data.maxpass) state = 1;

       // Debug.Log(maxpass.maxpass);

        if (state == 0)
        {
            SpriteRenderer spr = transform.GetComponent<SpriteRenderer>();
            spr.sprite = images[0];
        }
        if (state == 1)
        {
            SpriteRenderer spr = transform.GetComponent<SpriteRenderer>();
            spr.sprite = images[1];
        }

    }
}
