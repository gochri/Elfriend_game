using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resstart : MonoBehaviour {

    public game_main dif;
    public time T;

    public AudioClip Audioclip;
    public AudioSource AudioSource;

    void Start()
    {
        Audioclip = Resources.Load<AudioClip>("Music/ButtonClick");
        AudioSource = gameObject.AddComponent<AudioSource>();
        AudioSource.clip = Audioclip;
    }

    void OnMouseDown()
    {
        dif.restart();
        dif.nownum = 0;
        T.times = 0f;
        AudioSource.Play();
    }
    }
