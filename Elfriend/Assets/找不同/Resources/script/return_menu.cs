using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class return_menu : MonoBehaviour {

    public int id;

    public AudioClip Audioclip;
    public AudioSource AudioSource;

    // Use this for initialization
    void Start () {
        //Audioclip = Resources.Load<AudioClip>("Music/ButtonClick");
        //AudioSource = gameObject.AddComponent<AudioSource>();
        
        //AudioSource.clip = Audioclip;
    }

    void OnMouseDown()
    {
        //AudioSource.Play();

        sound.state = 1;

        if (id==1)
        SceneManager.LoadScene("passchoose");
          if(id==2)
            SceneManager.LoadScene("game");
        if (id == 3)
            SceneManager.LoadScene("mainmenu");

        //data.maxpass++;
        //Debug.Log(data.maxpass);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
