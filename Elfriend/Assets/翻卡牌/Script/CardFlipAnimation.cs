using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardFlipAnimation : MonoBehaviour,IPointerClickHandler
{

    Transform cardFront;
    Transform cardBack;
    float flipDuaration = 0.2f;
    public bool isInFront = false;
    public bool isOver = false;

    // Use this for initialization
    void Start ()
    {
        cardFront = transform.Find("CardFront");
        cardBack = transform.Find("CardBack");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        if(isInFront)
        {
            StartCoroutine(FlipCardToBack());
        }
        else
        {
            StartCoroutine(FlipCardToFront());
        }
        
    }


    IEnumerator FlipCardToFront()
    {
        GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().audioSound.clip =
                           GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().CardFlip;
        GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().audioSound.Play();
        //1、翻转反面到90度
        cardFront.gameObject.SetActive(false);
        cardBack.gameObject.SetActive(true);
        cardFront.rotation = Quaternion.identity;
        while(cardBack.rotation.eulerAngles.y<90)
        {
            cardBack.rotation *= Quaternion.Euler(0, Time.deltaTime*90f*(1f/ flipDuaration), 0);
            if(cardBack.rotation.eulerAngles.y > 90)
            {
                cardBack.rotation = Quaternion.Euler(0, 90, 0);
                break;
            }
                yield return new WaitForFixedUpdate();
        }

        //2、翻转正面到0度
        cardFront.gameObject.SetActive(true);
        cardBack.gameObject.SetActive(false);
        cardFront.rotation = Quaternion.Euler(0, 90, 0);
        while (cardFront.rotation.eulerAngles.y >0)
        {
            cardFront.rotation *= Quaternion.Euler(0, -Time.deltaTime * 90f * (1f / flipDuaration), 0);
            if (cardFront.rotation.eulerAngles.y >90)
            {
                cardFront.rotation = Quaternion.Euler(0, 0, 0);
                break;
            }
            yield return new WaitForFixedUpdate();
        }
        isInFront = true;
        Camera.main.gameObject.GetComponent<CardFlipGameMain>().CheckIsGameOver();

    }


    IEnumerator FlipCardToBack()
    {
        GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().audioSound.clip =
                          GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().CardFlip;
        GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().audioSound.Play();
        //1、翻转反面到90度
        cardFront.gameObject.SetActive(true);
        cardBack.gameObject.SetActive(false);
        cardFront.rotation = Quaternion.identity;
        while (cardFront.rotation.eulerAngles.y < 90)
        {
            cardFront.rotation *= Quaternion.Euler(0, Time.deltaTime * 90f * (1f / flipDuaration), 0);
            if (cardFront.rotation.eulerAngles.y > 90)
            {
                cardFront.rotation = Quaternion.Euler(0, 90, 0);
                break;
            }
            yield return new WaitForFixedUpdate();
        }

        //2、翻转正面到0度
        cardFront.gameObject.SetActive(false);
        cardBack.gameObject.SetActive(true);
        cardBack.rotation = Quaternion.Euler(0, 90, 0);
        while (cardBack.rotation.eulerAngles.y > 0)
        {
            cardBack.rotation *= Quaternion.Euler(0, -Time.deltaTime * 90f * (1f / flipDuaration), 0);
            if (cardBack.rotation.eulerAngles.y > 90)
            {
                cardBack.rotation = Quaternion.Euler(0, 0, 0);
                break;
            }
            yield return new WaitForFixedUpdate();
        }
        isInFront = false;
    }


    internal string GetCardImageName()
    {
        return cardFront.GetComponent<Image>().sprite.name;
    }

    internal void MatchSuccess()
    {
        isOver = true;
        cardFront.gameObject.SetActive(false);
        cardBack.gameObject.SetActive(false);
    }

    internal void MatchFail()
    {
        StartCoroutine(FlipCardToBack());
    }

    internal void SetDefaultState()
    {
        //this.cardFront.gameObject.SetActive(false);
        //this.cardBack.gameObject.SetActive(true);
        //this.isOver = false;
        //this.isInFront = false;
        //cardFront.rotation = Quaternion.identity;
        //cardBack.rotation = Quaternion.identity;

    }

}
