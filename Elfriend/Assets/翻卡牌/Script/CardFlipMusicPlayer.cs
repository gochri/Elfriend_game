using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlipMusicPlayer : MonoBehaviour
{
    public AudioSource audioMusic;
    public AudioSource audioSound;
    public AudioClip BackgroundMusic;
    public AudioClip ButtonClick;
    public AudioClip CardFlip;
    public AudioClip Correct;
    public AudioClip Error;
    public AudioClip Pass;

    // Use this for initialackization
    void Start ()
    {


        audioSound = gameObject.AddComponent<AudioSource>();
        

        ButtonClick = Resources.Load<AudioClip>("Music/ButtonClick");
        CardFlip = Resources.Load<AudioClip>("Music/CardFlip");
        Correct = Resources.Load<AudioClip>("Music/Correct");
        Error = Resources.Load<AudioClip>("Music/Error");
        Pass = Resources.Load<AudioClip>("Music/Pass");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
