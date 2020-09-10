//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFlipGameMain : MonoBehaviour
{
    //关卡按钮
    public Button btnLevel1;
    public Button btnLevel2;
    public Button btnLevel3;
    public Button btnLevel4;
    public Button btnLevel5;

    //游戏界面
    public Transform panelStart;
    public Transform panelGame;
    public Transform panelOver;

    //放卡牌的panel
    GameObject prePanel;
    GameObject gamePanel;

    //当前关卡
    int currentLevel;

    //关卡难度
    int[,] levelData = new int[5, 2]
    {
        {3,2 },
        {4,2},
        {5,2},
        {4,3 },
        {4,3 }
    };

    //星级判定
    int[,] levelJudge = new int[5, 2]
   {
        {10,15 },
        {15,19},
        {20,28},
        {25,35 },
        {32,40 }
   };

    //总共关卡
    int totalLevelNumber = 5;



    // Use this for initialization
    void Start()
    {
        prePanel = Resources.Load<GameObject>("Preform/Panel");
        Debug.Log(prePanel.name);
        btnLevel1.onClick.AddListener
            (
            () =>
            {
                PreButtonOnClick();
                LoadLevelCard(1, 3, 2);
            }
            );

        btnLevel2.onClick.AddListener
            (
            () =>
            {
                PreButtonOnClick();
                LoadLevelCard(2, 4, 2);
            }
            );

        btnLevel3.onClick.AddListener
            (
            () =>
            {
                PreButtonOnClick();
                LoadLevelCard(3, 5, 2);
            }
            );

        btnLevel4.onClick.AddListener
            (
            () =>
            {
                PreButtonOnClick();
                LoadLevelCard(4, 4, 3);
            }
            );

        btnLevel5.onClick.AddListener
            (
            () =>
            {
                PreButtonOnClick();
                LoadLevelCard(5, 4, 3);
            }
            );

        Button btnToStart = panelOver.Find("ButtonBackToStart").GetComponent<Button>();
        btnToStart.onClick.RemoveAllListeners();
        btnToStart.onClick.AddListener(ToGameStart);

        Button btnGameToStart = panelGame.Find("ButtonGameToStart").GetComponent<Button>();
        btnGameToStart.onClick.RemoveAllListeners();
        btnGameToStart.onClick.AddListener(ToGameStart);

        Button btnToNext = panelOver.Find("ButtonToNext").GetComponent<Button>();
        btnToNext.onClick.RemoveAllListeners();
        btnToNext.onClick.AddListener(ToGameNext);

        Button btnStartAgain = panelOver.Find("ButtonStartAgain").GetComponent<Button>();
        btnStartAgain.onClick.RemoveAllListeners();
        btnStartAgain.onClick.AddListener(StartAgain);
    }

	
	

    void LoadLevelCard(int levelNumber,int width, int height)
    {
        currentLevel = levelNumber;

        gamePanel= GameObject.Instantiate<GameObject>(prePanel);
        gamePanel.transform.SetParent(panelGame, false);
        //1、加载卡牌图片
        Sprite[] sps = Resources.LoadAll<Sprite>("Sprite");
       

        //2、计算需要加载卡牌的数量
        int totalCount = width * height / 2;
        //3、计算随机加载卡牌的索引
        List<Sprite> spsList = new List<Sprite>();
        for (int i = 0; i < sps.Length; i++)
        {
            spsList.Add(sps[i]);
        }

        List<Sprite> needShowCardList= new List<Sprite>();
        while(totalCount>0)
        {
            int randomIndex = Random.Range(0, spsList.Count);
            needShowCardList.Add(spsList[randomIndex]);
            needShowCardList.Add(spsList[randomIndex]);
            spsList.RemoveAt(randomIndex);
            totalCount--;
        }

        //打乱顺序
        for (int i = 0; i < needShowCardList.Count; i++)
        {
            Sprite temp = needShowCardList[i];
            int randomIndex = Random.Range(0, needShowCardList.Count);
            needShowCardList[i] = needShowCardList[randomIndex];
            needShowCardList[randomIndex] = temp;
        }



        //4、显示卡牌的UI上
        Transform contentRoot = panelGame.Find("Panel(Clone)");
        int maxCount = Mathf.Max(contentRoot.childCount, needShowCardList.Count);
        GameObject itemPrefab = contentRoot.GetChild(0).gameObject;
        for(int i=0;i<maxCount;i++)
        {
            GameObject itemObject = null;
            if(i<contentRoot.childCount)
            {
                itemObject = contentRoot.GetChild(i).gameObject;
            }
            else
            {
                itemObject = GameObject.Instantiate<GameObject>(itemPrefab);
                itemObject.transform.SetParent(contentRoot, false);
            }

            itemObject.transform.Find("CardFront").GetComponent<Image>().sprite = needShowCardList[i];
            CardFlipAnimation cardAniCtrl = itemObject.GetComponent<CardFlipAnimation>();
            cardAniCtrl.SetDefaultState();
        }

        GridLayoutGroup glg = contentRoot.GetComponent<GridLayoutGroup>();

        float panelWidth = width * glg.cellSize.x + glg.padding.left + glg.padding.right + (width - 1) * glg.spacing.x;
        float panelHeight = height * glg.cellSize.y + glg.padding.top + glg.padding.bottom + (height - 1) * glg.spacing.y;
        contentRoot.GetComponent<RectTransform>().sizeDelta = new Vector2(panelWidth, panelHeight);

    }


    public void CheckIsGameOver()
    {
        CardFlipAnimation[] allCards = GameObject.FindObjectsOfType<CardFlipAnimation>();

        if(allCards!=null&&allCards.Length>0)
        {
            List<CardFlipAnimation> cardInFront = new List<CardFlipAnimation>();

            for(int i=0;i<allCards.Length;i++)
            {
                CardFlipAnimation cardTem = allCards[i];
                if(cardTem.isInFront && !cardTem.isOver)
                {
                    cardInFront.Add(cardTem);
                }
                if(cardInFront.Count>=2)
                {
                    
                    string cardImageName1= cardInFront[0].GetCardImageName();
                    string cardImageName2 = cardInFront[1].GetCardImageName();
                    if(cardImageName1==cardImageName2)
                    {
                        GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().audioSound.clip =
                           GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().Correct;
                        GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().audioSound.Play();
                        cardInFront[0].MatchSuccess();
                        cardInFront[1].MatchSuccess();

                        //把这两张牌标记为匹配结束
                    }
                    else
                    {
                        cardInFront[0].MatchFail();
                        cardInFront[1].MatchFail();
                        //把两张牌翻到反面
                    }
                    allCards = GameObject.FindObjectsOfType<CardFlipAnimation>();
                    bool isAllOver = true;
                    for (int o=0;o<allCards.Length;o++)
                    {
                        isAllOver &= allCards[o].isOver;
                    }
                    if(isAllOver)
                    {
                        GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().audioSound.clip =
                            GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().Pass;
                        GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().audioSound.Play();
                        panelOver.Find("TextTotalTime").GetComponent<Text>().text = CardFlipClock.timeStr;
                        panelGame.gameObject.GetComponentInChildren<CardFlipClock>().ZeroTime();
                        ToGameOver();
                    }
                    break;
                }
            }

        }


    }

    public void ToGameOver()
    {
       
        panelStart.gameObject.SetActive(false);       
        panelGame.gameObject.SetActive(false);
        Sprite yellowStart = panelOver.Find("JudgeStar").GetChild(0).GetComponent<Image>().sprite;
        if (CardFlipClock.totalTime <levelJudge[currentLevel - 1, 0])
            for (int i = 0; i < 3; i++)
            {
                panelOver.Find("JudgeStar").GetChild(i).GetComponent<Image>().sprite = yellowStart;
            }
        if (CardFlipClock.totalTime>=levelJudge[currentLevel - 1, 0]
           && CardFlipClock.totalTime <=levelJudge[currentLevel - 1, 1]
           )
            for (int i = 0; i < 2; i++)
            {
                panelOver.Find("JudgeStar").GetChild(i).GetComponent<Image>().sprite = yellowStart;
            }
        Destroy(gamePanel);
        panelOver.gameObject.SetActive(true);
    }

    public void ToGameStart()
    {
        GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().audioSound.clip =
                         GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().ButtonClick;
        GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().audioSound.Play();
        if (gamePanel == true)
            Destroy(gamePanel);
        panelStart.gameObject.SetActive(true);
        panelGame.gameObject.SetActive(false);
        panelOver.gameObject.SetActive(false);
    }

    public void ToGameNext()
    {
        if(currentLevel<totalLevelNumber)
        {
            GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().audioSound.clip =
                         GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().ButtonClick;
            GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().audioSound.Play();
            panelStart.gameObject.SetActive(false);
            panelGame.gameObject.SetActive(true);
            panelOver.gameObject.SetActive(false);
            LoadLevelCard(currentLevel + 1, levelData[currentLevel, 0], levelData[currentLevel, 1]);
        }
       
    }

    public void StartAgain()
    {
        GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().audioSound.clip =
                         GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().ButtonClick;
        GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().audioSound.Play();
        panelStart.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        panelOver.gameObject.SetActive(false);
        LoadLevelCard(currentLevel, levelData[currentLevel - 1,0], levelData[currentLevel - 1, 1]);
    }

    public void PreButtonOnClick()
    {
        GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().audioSound.clip =
                          GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().ButtonClick;
        GameObject.Find("MusicPlayer").GetComponent<CardFlipMusicPlayer>().audioSound.Play();
        panelStart.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
    }
}

