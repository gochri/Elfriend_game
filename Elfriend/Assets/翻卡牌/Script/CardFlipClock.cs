using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFlipClock : MonoBehaviour {

    //设定计时器的时，分，秒
    int second = 0;
    int minute = 0;
    int hour = 0;
    //设定需要显示到屏幕上的字符串
    string s;
    string m;
    string h;
    //用来计算时间的变量
    float time = 0;
    static public int totalTime=0;
    static public string timeStr = "0:0:0";
    //是否打开计时器
    // Use this for initialization

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        TimeChange();
        this.transform.GetComponent<Text>().text = timeStr;
    }

    void TimeChange()
    {
        //Time.deltaTime是执行一帧需要的时间
        time += Time.deltaTime;

        if (time >= 1)
        {
            //当time>=1时，表示Update执行总时间到了1秒
            second++;
            totalTime++;
            //这时需要time去重新记录Update执行的时间，要减去1(有可能会大于1)
            time -= 1;
        }
        if (second == 60)
        {
            //秒和分钟的关系
            minute++;
            second = 0;
        }
        if (minute == 60)
        {
            //分钟和小时的关系
            hour++;
            minute = 0;
        }
        s = "" + second;
        m = "" + minute;
        h = "" + hour;
        timeStr = h + ":" + m + ":" + s;
    }

    public void ZeroTime()
    {
        second = 0;
        minute = 0;
        hour = 0;
        time = 0;
    }
}
