using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour {

    public Sprite[] images;
    public int id;

    float m_timer = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        m_timer += Time.time;

        if (game_main.time < 30 / 3)
        {
            if (m_timer > 100) lighten_star1();
            if (m_timer > 200) lighten_star2();
            if (m_timer > 300) lighten_star3();
        }

        if (game_main.time >30 / 3&& game_main.time < 60 / 3)
        {
            if (m_timer > 100) lighten_star1();
            if (m_timer > 200) lighten_star2();
        }

        if (game_main.time <30&& game_main.time > 60 / 3)
        {
            if (m_timer > 100) lighten_star1();
         
        }

    }

    void lighten_star1()
    {
        if (id == 1)
        {
            SpriteRenderer spr = transform.GetComponent<SpriteRenderer>();
            spr.sprite = images[1];
        }
    }
    void lighten_star2()
    {
        if (id == 2)
        {
            SpriteRenderer spr = transform.GetComponent<SpriteRenderer>();
            spr.sprite = images[1];
        }
    }
    void lighten_star3()
    {
        if (id == 3)
        {
            SpriteRenderer spr = transform.GetComponent<SpriteRenderer>();
            spr.sprite = images[1];
        }
    }
}
