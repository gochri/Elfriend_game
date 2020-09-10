using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HistoricalRecords
{
    public int timeCount;
    public string timeString;
}
public class SchulteGridGameMain : MonoBehaviour
{

    public Button buttonLevel1;
    public Button buttonLevel2;
    public Button buttonLevel3;
    public Button buttonLevel4;
    public Button buttonLevel5;
    public Button buttonToStart;
    public Button buttonStartAgain;
    public Button buttonBackToStart;

    public Transform panelStart;
    public Transform panelGame;
    public Transform panelOver;

    Sprite[] levelSprite;
    int currentLevel;
    public GameObject preButton;
    static public List<int> needClickNumber;

    int totalLevelNumber = 5;
    int[] levelDate = { 3, 4, 4, 5, 5 };

    HistoricalRecords historicalRecords;

    // Use this for initialization
    void Start ()
    {
        historicalRecords = new HistoricalRecords();
        historicalRecords.timeCount = 10000;
        historicalRecords.timeString = "0:0:0";


        levelSprite = Resources.LoadAll<Sprite>("LevelAnimal");
        needClickNumber = new List<int>();
        buttonLevel1.onClick.AddListener(() => 
        {
            PreButtonOnClick();
            LoadLevel(1,3, 3);
        }        
        );

        buttonLevel2.onClick.AddListener(() =>
        {
            PreButtonOnClick();
            LoadLevel(2,4, 4);
        }
        );

        buttonLevel3.onClick.AddListener(() =>
        {
            PreButtonOnClick();
            LoadLevel(3,4, 4);
        }
        );

        buttonLevel4.onClick.AddListener(() =>
        {
            PreButtonOnClick();
            LoadLevel(4, 5, 5);
        }
       );

        buttonLevel5.onClick.AddListener(() =>
        {
            PreButtonOnClick();
            LoadLevel(5, 5, 5);
        }
       );

        buttonToStart.onClick.AddListener(ToGameStart);
        buttonStartAgain.onClick.AddListener(StartAgain);
        Button buttonBackToStart = panelOver.Find("ButtonBackToStart").GetComponent<Button>();
        buttonBackToStart.onClick.RemoveAllListeners();
        buttonBackToStart.onClick.AddListener(ToGameStart);
    }


    void LoadLevel(int current,int width,int height)
    {

        currentLevel = current;
        //Debug.Log(currentLevel);
        panelGame.Find("ImageLevel").GetComponent<Image>().sprite = levelSprite[currentLevel - 1];

        //计算需要加载卡牌的数量
        int totalCount = width * height;

        //加载需要被点击的数列
        for (int i = 1; i <= totalCount; i++)
        {
            needClickNumber.Add(i);
            //Debug.Log("needClickNumber:"+i);
        }
        //计算随机加载卡牌的索引

        List<int> numberList = new List<int>();
        for(int i=1;i<=totalCount; i++)
        {
            numberList.Add(i);
        }

        List<int> needShowNumberList = new List<int>();
        while (totalCount > 0)
        {
            int randomIndex = Random.Range(0, numberList.Count);
            needShowNumberList.Add(numberList[randomIndex]);
            //Debug.Log("needShowNumberList:"+needShowNumberList[needShowNumberList.Count-1]);
            numberList.RemoveAt(randomIndex);
            totalCount--;
            
                
        }
       
        //显示卡牌的UI上
        Transform contentRoot = panelGame.Find("Panel");
        //int maxCount = Mathf.Max(contentRoot.childCount, needShowNumberList.Count);
        int maxCount = needShowNumberList.Count;
        GameObject itemPrefab = contentRoot.GetChild(0).gameObject;

        for (int i = contentRoot.childCount - 1; i >= 1; i--)
        {
            Destroy(contentRoot.GetChild(i).gameObject);
        }
        //itemPrefab.transform.SetParent(contentRoot, false);
        for (int i = 1; i < maxCount; i++)
        {
            GameObject itemObject = null;
            //if(i< contentRoot.childCount)
            //{
            //    itemObject = contentRoot.GetChild(i).gameObject;
            //}
            //else
            {
                itemObject = GameObject.Instantiate<GameObject>(itemPrefab);
                itemObject.transform.SetParent(contentRoot, false);
            }
            //itemObject.GetComponent<Image>().gameObject.SetActive(false);
            itemObject.GetComponentInChildren<Text>().text = needShowNumberList[i].ToString();
            itemPrefab.GetComponentInChildren<Text>().text = needShowNumberList[0].ToString();


        }
        GridLayoutGroup glg = contentRoot.GetComponent<GridLayoutGroup>();
        //int gridCellSize=panelGame.
       
       
        float panelWidth = width * glg.cellSize.x + glg.padding.left + glg.padding.right + (width - 1) * glg.spacing.x;
        float panelHeight = height * glg.cellSize.y + glg.padding.top + glg.padding.bottom + (height - 1) * glg.spacing.y;
        contentRoot.GetComponent<RectTransform>().sizeDelta = new Vector2(panelWidth, panelHeight);

    }

    public void CheckIsGameOver()
    {
        if (needClickNumber.Count == 0)
        {
            GameObject.Find("MusicPlayer").GetComponent<SchulteGridMusicPlayer>().audioSound.clip =
                      GameObject.Find("MusicPlayer").GetComponent<SchulteGridMusicPlayer>().Pass;
            GameObject.Find("MusicPlayer").GetComponent<SchulteGridMusicPlayer>().audioSound.Play();

            needClickNumber.Clear();

            if(historicalRecords.timeCount>=SchulteGridClock.totalTime)
            {
                historicalRecords.timeCount = SchulteGridClock.totalTime;
                historicalRecords.timeString = SchulteGridClock.timeStr;
            }
            panelOver.Find("HighestTimeText").GetComponent<Text>().text = historicalRecords.timeString;
            panelOver.Find("TotalTimeText").GetComponent<Text>().text = SchulteGridClock.timeStr;
            panelGame.gameObject.GetComponentInChildren<SchulteGridClock>().ZeroTime();
            ToGameOver();

        }            

    }

    public void ToGameOver()
    {
       
        panelStart.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(false);
        panelOver.gameObject.SetActive(true);
        
    }
    // Update is called once per frame

    public void ToGameStart()
    {
        GameObject.Find("MusicPlayer").GetComponent<SchulteGridMusicPlayer>().audioSound.clip =
                         GameObject.Find("MusicPlayer").GetComponent<SchulteGridMusicPlayer>().ButtonClick;
        GameObject.Find("MusicPlayer").GetComponent<SchulteGridMusicPlayer>().audioSound.Play();
        panelGame.gameObject.GetComponentInChildren<SchulteGridClock>().ZeroTime();
        needClickNumber.Clear();
        panelStart.gameObject.SetActive(true);
        panelGame.gameObject.SetActive(false);
        panelOver.gameObject.SetActive(false);
        
    }

    public void StartAgain()
    {
        GameObject.Find("MusicPlayer").GetComponent<SchulteGridMusicPlayer>().audioSound.clip =
                         GameObject.Find("MusicPlayer").GetComponent<SchulteGridMusicPlayer>().ButtonClick;
        GameObject.Find("MusicPlayer").GetComponent<SchulteGridMusicPlayer>().audioSound.Play();
        panelGame.gameObject.GetComponentInChildren<SchulteGridClock>().ZeroTime();
        needClickNumber.Clear();
        panelStart.gameObject.SetActive(false);      
        panelOver.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        LoadLevel(currentLevel, levelDate[currentLevel - 1], levelDate[currentLevel - 1]); ;
        
    }

    public void PreButtonOnClick()
    {
        GameObject.Find("MusicPlayer").GetComponent<SchulteGridMusicPlayer>().audioSound.clip =
                          GameObject.Find("MusicPlayer").GetComponent<SchulteGridMusicPlayer>().ButtonClick;
        GameObject.Find("MusicPlayer").GetComponent<SchulteGridMusicPlayer>().audioSound.Play();
        panelStart.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
    }
   

    

}
