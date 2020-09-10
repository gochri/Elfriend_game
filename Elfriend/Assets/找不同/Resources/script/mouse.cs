using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mouse : MonoBehaviour {

    public game_main scr;


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

      


        if (Input.GetMouseButtonDown(0))  //鼠标点击事件
        {
            Vector2 dianV = Input.mousePosition;  //鼠标点击位置
            //Debug.Log(dianV);

            if (110 < dianV.x && dianV.x < 840 && 100 < dianV.y && dianV.y < 340)
            {

                int num = this.GetComponent<game_main>().Scenes[scr.ID].number;
                for (int i = 0; i < num; i++)
                {
                    

                    string ii = i.ToString();
                    Vector2 dianY = this.GetComponent<game_main>().Scenes[scr.ID].pic[i];
                    dianY = Camera.main.WorldToScreenPoint(dianY);

                    if (-18 < (dianY.x - dianV.x) && (dianY.x - dianV.x) < 18 && -18 < (dianY.y - dianV.y) && (dianY.y - dianV.y) < 18&& scr.pic_state[i] == 0)
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

    
}
