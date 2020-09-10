using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class passenter1_mouse : MonoBehaviour {

    public pass1_choose state;

    // Use this for initialization
    void Start () {
        state = this.GetComponent<pass1_choose>();
    }
	
	// Update is called once per frame
	
        void OnMouseDown()
    {
       
        if (state.state == 1)
        {
            sound.state = 1;
            SceneManager.LoadScene("game");
            data.nowpass = state.ID;
            // Debug.Log(data.nowpass);
        }


    }
    void Update()
    {
        
    }
    
}
