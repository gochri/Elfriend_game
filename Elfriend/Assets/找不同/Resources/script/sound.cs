using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour {

    //public AudioClip Audioclip;
  //  public AudioSource AudioSource;

   
    public AudioClip ButtonClick;
    public AudioClip CardFlip;
    public AudioClip Correct;
    public AudioClip Error;
    public AudioClip Pass;

    public static int state;


    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
        state = 0;

        CardFlip = Resources.Load<AudioClip>("Music/CardFlip");
        Correct = Resources.Load<AudioClip>("Music/Correct");
        Error = Resources.Load<AudioClip>("Music/Error");
        Pass = Resources.Load<AudioClip>("Music/Pass");
        ButtonClick = Resources.Load<AudioClip>("Music/ButtonClick");
    }
	
	// Update is called once per frame
	void Update () {
        if (state == 1)
        {
            this.GetComponent<AudioSource>().clip = ButtonClick;
            this.GetComponent<AudioSource>().Play();
            state = 0;
        }
        if (state == 2)
        {
            this.GetComponent<AudioSource>().clip = Correct;
            this.GetComponent<AudioSource>().Play();
            state = 0;
        }
        if (state == 3)
        {
            this.GetComponent<AudioSource>().clip = Error;
            this.GetComponent<AudioSource>().Play();
            state = 0;
        }
        if (state == 4)
        {
            this.GetComponent<AudioSource>().clip = Pass;
            this.GetComponent<AudioSource>().Play();
            state = 0;
        }
    }
}
