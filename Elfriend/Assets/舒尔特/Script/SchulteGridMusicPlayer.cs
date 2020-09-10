using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchulteGridMusicPlayer : MonoBehaviour
{
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
}
