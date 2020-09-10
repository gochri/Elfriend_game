using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ButtonAnimation : MonoBehaviour,IPointerClickHandler
{
   
    public Sprite imageWrong;
    public Sprite imageRight;
    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        if(
            this.GetComponentInChildren<Text>().text== SchulteGridGameMain.needClickNumber[0].ToString()
            )
        {
            GameObject.Find("MusicPlayer").GetComponent<SchulteGridMusicPlayer>().audioSound.clip =
                     GameObject.Find("MusicPlayer").GetComponent<SchulteGridMusicPlayer>().Correct;
            GameObject.Find("MusicPlayer").GetComponent<SchulteGridMusicPlayer>().audioSound.Play();
            //Debug.Log("click");
            SchulteGridGameMain.needClickNumber.RemoveAt(0);
            Camera.main.gameObject.GetComponent<SchulteGridGameMain>().CheckIsGameOver();

        }
        else
        {
            GameObject.Find("MusicPlayer").GetComponent<SchulteGridMusicPlayer>().audioSound.clip =
                    GameObject.Find("MusicPlayer").GetComponent<SchulteGridMusicPlayer>().Error;
            GameObject.Find("MusicPlayer").GetComponent<SchulteGridMusicPlayer>().audioSound.Play();
            StartCoroutine(ChangeWrongButtonColor());
        }
        

    }

    IEnumerator ChangeWrongButtonColor()
    {
        this.GetComponentInChildren<Image>().sprite = imageWrong;
        yield return new WaitForSeconds(1);
        this.GetComponentInChildren<Image>().sprite = imageRight; ;
        
    }

 
}
