using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_music_1 : MonoBehaviour {

    public GameObject obje;
    GameObject obj = null;

    public GameObject audiosource;
    GameObject Audiosource = null;

    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("music");
        if (obj == null)
        {
            obj = (GameObject)Instantiate(obje);
           
        }

        Audiosource = GameObject.FindGameObjectWithTag("audiosource");
        if (Audiosource == null)
        {
            Audiosource = (GameObject)Instantiate(audiosource);

        }

    }

    
}
