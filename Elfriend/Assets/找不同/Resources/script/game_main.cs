using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class game_main : MonoBehaviour {


     public int NUM;//不同个数
     public int nownum;//已找出个数
     public int nowpass;
     public int PASS;
     public int ID;
     public time T;
     public static float time;

    //public star id;


    




    public class scenes
    {
       public  int id;//序号
       public int number;//不同个数
       public Vector2[] pic;
    };

    public Sprite sk;
    

    public scenes[] Scenes;
    public Sprite[] backscenes;

    public int[] pic_state;//每个差异点的状态，0没找到，1找到

    void init()
    {
        
        
        nowpass = 1;
        PASS = 6;

        Scenes = new scenes[PASS];

        Scenes[0] = new scenes();
        Scenes[0].id = 0;
        Scenes[0].number = 8;
        Scenes[0].pic = new Vector2[Scenes[0].number];
        Scenes[0].pic[0] = new Vector2(-6.5f, 1.3f);//7.8
        Scenes[0].pic[1] = new Vector2(1.2f, 1.3f);
        Scenes[0].pic[2] = new Vector2(-4.6f, 0.0f);
        Scenes[0].pic[3] = new Vector2(3.2f, 0.0f);
        Scenes[0].pic[4] = new Vector2(-4.5f, 0.5f);
        Scenes[0].pic[5] = new Vector2(3.3f, 0.5f);
        Scenes[0].pic[6] = new Vector2(-1.96f, -0.3f);
        Scenes[0].pic[7] = new Vector2(5.84f, -0.3f);


        Scenes[1] = new scenes();
        Scenes[1].id = 1;
        Scenes[1].number = 8;
        Scenes[1].pic = new Vector2[Scenes[1].number];
        Scenes[1].pic[0] = new Vector2(-2.73f, -2.3f);//
        Scenes[1].pic[1] = new Vector2(5.07f, -2.3f);
        Scenes[1].pic[2] = new Vector2(-4.26f, 0.65f);
        Scenes[1].pic[3] = new Vector2(3.54f, 0.65f);
        Scenes[1].pic[4] = new Vector2(-6.73f, -1.33f);
        Scenes[1].pic[5] = new Vector2(1.07f, -1.33f);
        Scenes[1].pic[6] = new Vector2(-4.15f, -0.64f);
        Scenes[1].pic[7] = new Vector2(3.65f, -0.64f);


        Scenes[2] = new scenes();
        Scenes[2].id = 2;
        Scenes[2].number = 8;
        Scenes[2].pic = new Vector2[Scenes[0].number];
        Scenes[2].pic[0] = new Vector2(-2.18f, -1.68f);//7.8
        Scenes[2].pic[1] = new Vector2(5.62f, -1.68f);
        Scenes[2].pic[2] = new Vector2(-3.48f, -0.53f);
        Scenes[2].pic[3] = new Vector2(4.32f, -0.53f);
        Scenes[2].pic[4] = new Vector2(-2.29f, 0.67f);
        Scenes[2].pic[5] = new Vector2(5.51f, 0.67f);
        Scenes[2].pic[6] = new Vector2(-5.41f, 0.75f);
        Scenes[2].pic[7] = new Vector2(2.39f, 0.75f);


        Scenes[3] = new scenes();
        Scenes[3].id = 3;
        Scenes[3].number = 8;
        Scenes[3].pic = new Vector2[Scenes[0].number];
        Scenes[3].pic[0] = new Vector2(-2.29f, 0.66f);//7.8
        Scenes[3].pic[1] = new Vector2(5.51f, 0.66f);
        Scenes[3].pic[2] = new Vector2(-4.55f, 0.26f);
        Scenes[3].pic[3] = new Vector2(3.25f, 0.26f);
        Scenes[3].pic[4] = new Vector2(-6.73f, -1.86f);
        Scenes[3].pic[5] = new Vector2(1.07f, -1.86f);
        Scenes[3].pic[6] = new Vector2(-1.56f, 0f);
        Scenes[3].pic[7] = new Vector2(6.24f, 0f);




        Scenes[4] = new scenes();
        Scenes[4].id = 4;
        Scenes[4].number = 6;
        Scenes[4].pic = new Vector2[Scenes[4].number];
        Scenes[4].pic[0] = new Vector2(-4.04f, -1.58f);//7.8
        Scenes[4].pic[1] = new Vector2(3.76f, -1.58f);
        Scenes[4].pic[2] = new Vector2(-1.11f, 0.79f);
        Scenes[4].pic[3] = new Vector2(6.69f, 0.79f);
        Scenes[4].pic[4] = new Vector2(-2.71f, -1.73f);
        Scenes[4].pic[5] = new Vector2(5.09f, -1.73f);



        Scenes[5] = new scenes();
        Scenes[5].id = 5;
        Scenes[5].number = 8;
        Scenes[5].pic = new Vector2[Scenes[0].number];
        Scenes[5].pic[0] = new Vector2(-4.94f, 0.79f);//7.8
        Scenes[5].pic[1] = new Vector2(2.86f, 0.79f);
        Scenes[5].pic[2] = new Vector2(-3.44f, 0.23f);
        Scenes[5].pic[3] = new Vector2(4.36f, 0.23f);
        Scenes[5].pic[4] = new Vector2(-0.36f, -1.22f);
        Scenes[5].pic[5] = new Vector2(7.44f, -1.22f);
        Scenes[5].pic[6] = new Vector2(-1.67f, 0.11f);
        Scenes[5].pic[7] = new Vector2(6.13f, 0.11f);
        
    }

    void upimage()
    {
       
        NUM = Scenes[ID].number;//总dif个数
        nownum = 0;//当前找到dif个数
        



        for (int i = 0; i < NUM; i++)
        {
            string tag = i.ToString();
            GameObject sd = new GameObject(tag);
            sd.AddComponent<SpriteRenderer>();

            sd.AddComponent<BoxCollider2D>();
            sd.GetComponent<SpriteRenderer>().sprite = sk;
            sd.transform.position = Scenes[ID].pic[i];
            sd.GetComponent<SpriteRenderer>().sortingOrder = -2;
          
        }
    }
   public void restart()
    {

        for (int i = 0; i < NUM; i++)
        {

            string ii = i.ToString();
            GameObject obj = GameObject.Find(ii);
            obj.GetComponent<SpriteRenderer>().sortingOrder = -2;
        }

        for (int i = 0; i < Scenes[ID].number; i++)
        {
            pic_state[i] = 0;
        }

    }


    void destroy()
    {

        for (int i = 0; i < NUM; i++)
        {
            string tag = i.ToString();
            Destroy(GameObject.Find(tag));
        }

    }

    // Use this for initialization
    void Start()
    {
        ID =data.nowpass;
        init();
        upimage();

        this.GetComponent<SpriteRenderer>().sprite = backscenes[ID];

        
        pic_state = new int[Scenes[ID].number];
        for (int i = 0; i < Scenes[ID].number; i++)
        {
            pic_state[i] = 0;
        }

    }

    // Update is called once per frame
    void Update () {
      

        //通过判定
        if (nownum == NUM)
        {
            destroy();
            time = T.times;


            sound.state = 4;
            SceneManager.LoadScene("gamewin");
            if(data.nowpass==data.maxpass&& data.maxpass!=5)
            data.maxpass++;
            
        }

    }
}
