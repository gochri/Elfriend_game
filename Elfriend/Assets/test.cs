using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public game_main scr;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            Vector2 dianV = Input.GetTouch(0).position;


            
                int num = this.GetComponent<game_main>().Scenes[scr.ID].number;
                for (int i = 0; i < num; i++)
                {
                    string ii = i.ToString();
                    Vector2 dianY = this.GetComponent<game_main>().Scenes[scr.ID].pic[i];
                    dianY = Camera.main.WorldToScreenPoint(dianY);

                    if (-18 < (dianY.x - dianV.x) && (dianY.x - dianV.x) < 18 && -18 < (dianY.y - dianV.y) && (dianY.y - dianV.y) < 18 && scr.pic_state[i] == 0)
                    {
                        sound.state = 2;
                        GameObject obj = GameObject.Find(ii);
                        obj.GetComponent<SpriteRenderer>().sortingOrder = 0;

                        int i1 = int.Parse(ii);
                        scr.pic_state[i1] = 1;

                        //Debug.Log(i1);

                        if (i1 % 2 == 1) i1 = i1 - 1;
                        else if (i1 % 2 == 0) i1 = i1 + 1;
                        scr.pic_state[i1] = 1;

                        //Debug.Log(i1);

                        string ii1 = i1.ToString();
                        GameObject obj1 = GameObject.Find(ii1);
                        obj1.GetComponent<SpriteRenderer>().sortingOrder = 0;
                        scr.nownum += 2;

                    }


                }
                if (sound.state == 0) sound.state = 3;




            }
        

    }
}
