using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickElvesControl : MonoBehaviour,IPointerClickHandler
{


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("MusicPlayer").GetComponent<FindElvesMusicPlayer>().CorrectSoundPlay();
        Camera.main.gameObject.GetComponent<FindElvesGameMain>().needClickNimber-=1;
        this.gameObject.SetActive(false);
        Camera.main.gameObject.GetComponent<FindElvesGameMain>().ChangeNumberCount();
        Camera.main.gameObject.GetComponent<FindElvesGameMain>().CheckGameOver();
        //int i = Camera.main.gameObject.GetComponent<GameMain>().needClickNimber;
        //Debug.Log(i);
    }




}
