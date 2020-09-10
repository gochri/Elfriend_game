using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pass : MonoBehaviour
{

    public int id;
    Vector3 returnscale;
    void Start()
    {
        returnscale = this.transform.localScale;
    }
    // Use this for initialization
    void OnMouseDown()
    {

        if(id==1)
            SceneManager.LoadScene("passchoose");
        if(id==2)
            SceneManager.LoadScene("gamelevel");
        if(id==3)
            SceneManager.LoadScene("FindElves");
        if(id==4)
            SceneManager.LoadScene("SchulteGrid");
        if (id == 5)
            SceneManager.LoadScene("CardFlip");
    }

    private void OnMouseEnter()
    {
        this.transform.localScale = 1.5f * Vector3.one;
    }

    private void OnMouseExit()
    {
        this.transform.localScale = returnscale;
    }
}
