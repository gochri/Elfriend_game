using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindElvesMusicPlayer : MonoBehaviour {

    public AudioSource audioMusic;
    public AudioSource audioSound;
    public AudioClip BackgroundMusic;
    public AudioClip ButtonClick;
    public AudioClip Correct;
    public AudioClip Error;
    public AudioClip Pass;

    // Use this for initialackization
    void Start()
    {
       


        audioSound = gameObject.AddComponent<AudioSource>();


        ButtonClick = Resources.Load<AudioClip>("Music/ButtonClick");       
        Correct = Resources.Load<AudioClip>("Music/Correct");
        Error = Resources.Load<AudioClip>("Music/Error");
        Pass = Resources.Load<AudioClip>("Music/Pass");

    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    public void ButtonClickSoundPlay()
    {
        audioSound.clip = ButtonClick;
        audioSound.Play();
    }

    public void CorrectSoundPlay()
    {
        audioSound.clip = Correct;
        audioSound.Play();
    }

    public void ErrorSoundPlay()
    {
        audioSound.clip = Error;
        audioSound.Play();
    }

    public void PassSoundPlay()
    {
        audioSound.clip = Pass;
        audioSound.Play();
    }

}
