using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindElvesGameMain : MonoBehaviour
{
    //选关按钮
    public Button btnLevel1;
    public Button btnLevel5;
    //public Button btnLevel2;

    //游戏界面
    public Transform panelStart;
    public Transform panelGame;
    public Transform panelOver;

    //存储地图
    GameObject[] mapPreform;
    Sprite[] numberCount;


    //当前游戏界面
    GameObject itemObject;

    //需要点击的精灵数量
    public int needClickNimber;

    //当前关卡
    public int currentLevel=1;

    //总共关卡
    public int totalLevel = 1;

    int totalLevelNumber = 5;
    //关卡星级
    int[,] levelJudge = new int[5, 2]
    {
        {15,25 },
        {15,25},
        {20,25 },
        {40,60 },
        {40,60 }
    };

    //关卡信息
    int[] levelData = {4,4,5,5,5 };
       

    void Start ()
    {
        mapPreform= Resources.LoadAll<GameObject>("Preform");
        numberCount= Resources.LoadAll<Sprite>("NumberCount");
        

        btnLevel1.onClick.AddListener
            (
            () =>
            {
                PreButtonOnClick();
                LoadLevel(1,4);
            }
            );

        btnLevel5.onClick.AddListener
            (
            () =>
            {
                PreButtonOnClick();
                LoadLevel(5, 5);
            }
            );

        Button btnToStart = panelOver.Find("ButtonToStart").GetComponent<Button>();
        btnToStart.onClick.RemoveAllListeners();
        btnToStart.onClick.AddListener(ToGameStart);

        Button btnStartAgain = panelOver.Find("ButtonStartAgain").GetComponent<Button>();
        btnStartAgain.onClick.RemoveAllListeners();
        btnStartAgain.onClick.AddListener(StartAgain);

        Button btnToNext = panelOver.Find("ButtonToNext").GetComponent<Button>();
        btnToNext.onClick.RemoveAllListeners();
        btnToNext.onClick.AddListener(ToGameNext);
    }
	
    void LoadLevel(int levelNumber,int clickNumber)
    {
        
        needClickNimber = clickNumber;
        currentLevel = levelNumber;
        if (totalLevel < currentLevel)
            totalLevel = currentLevel;
        panelStart.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        itemObject = GameObject.Instantiate<GameObject>(mapPreform[levelNumber-1]);
        itemObject.transform.Find("NumberCount").GetComponent<Image>().sprite = numberCount[needClickNimber];
       
        Button buttonGameToSart = itemObject.transform.Find("ButtonGameToSart").GetComponent<Button>();
        buttonGameToSart.onClick.AddListener(ToGameStart);
        itemObject.transform.SetParent(panelGame, false);  
        

    }

    public void ChangeNumberCount()
    {
        itemObject.transform.Find("NumberCount").GetComponent<Image>().sprite = numberCount[needClickNimber];
    }

    public void CheckGameOver()
    {
        if (needClickNimber == 0)
        {
            GameObject.Find("MusicPlayer").GetComponent<FindElvesMusicPlayer>().PassSoundPlay();
            ToGameOver();
        }
            

    }

    public void ToGameOver()
    {
        panelStart.gameObject.SetActive(false);       
        panelGame.gameObject.SetActive(false);        
        panelOver.GetComponentInChildren<Text>().text
            = itemObject.gameObject.GetComponentInChildren<FindElvesClock>().timeStr;

        Sprite yellowStart = panelOver.Find("JudgeStar").GetChild(0).GetComponent<Image>().sprite;
        if (
            itemObject.gameObject.GetComponentInChildren<FindElvesClock>().totalTime<
            levelJudge[currentLevel-1,0]
            )
            for(int i=0;i<3;i++)
            {
                panelOver.Find("JudgeStar").GetChild(i).GetComponent<Image>().sprite = yellowStart;
            }

        if (
           itemObject.gameObject.GetComponentInChildren<FindElvesClock>().totalTime >=
           levelJudge[currentLevel - 1, 0]
           && itemObject.gameObject.GetComponentInChildren<FindElvesClock>().totalTime <=
           levelJudge[currentLevel - 1, 1]
           )
            for (int i = 0; i < 2; i++)
            {
                panelOver.Find("JudgeStar").GetChild(i).GetComponent<Image>().sprite = yellowStart;
            }

        Destroy(itemObject);
        panelOver.gameObject.SetActive(true);
    }

    public void ToGameStart()
    {
        GameObject.Find("MusicPlayer").GetComponent<FindElvesMusicPlayer>().ButtonClickSoundPlay();
        if (itemObject==true)
            Destroy(itemObject);
        panelStart.gameObject.SetActive(true);
        Sprite passedLevel = panelStart.GetChild(0).GetChild(0).GetComponent<Image>().sprite;
        for (int i = 0; i < totalLevel; i++)
            panelStart.Find("PanelButtonGroup").GetChild(i).GetComponent<Image>().sprite = passedLevel;
        panelGame.gameObject.SetActive(false);
        panelOver.gameObject.SetActive(false);
    }

    public void StartAgain()
    {
        GameObject.Find("MusicPlayer").GetComponent<FindElvesMusicPlayer>().ButtonClickSoundPlay();
        panelStart.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        panelOver.gameObject.SetActive(false);
        LoadLevel(currentLevel, levelData[currentLevel - 1]);
    }

    public void ToGameNext()
    {
        
        GameObject.Find("MusicPlayer").GetComponent<FindElvesMusicPlayer>().ButtonClickSoundPlay();
        if (currentLevel<totalLevelNumber)
        {
            panelStart.gameObject.SetActive(false);
            panelGame.gameObject.SetActive(true);
            panelOver.gameObject.SetActive(false);
            LoadLevel(currentLevel + 1, levelData[currentLevel]);
        }
            
    }
    // Update is called once per frame
    void Update ()
    {
		
	}

    public void PreButtonOnClick()
    {
        GameObject.Find("MusicPlayer").GetComponent<FindElvesMusicPlayer>().audioSound.clip =
                          GameObject.Find("MusicPlayer").GetComponent<FindElvesMusicPlayer>().ButtonClick;
        GameObject.Find("MusicPlayer").GetComponent<FindElvesMusicPlayer>().audioSound.Play();
        panelStart.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
    }

    

}
