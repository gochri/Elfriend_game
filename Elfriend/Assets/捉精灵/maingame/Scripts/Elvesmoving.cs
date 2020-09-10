using UnityEngine;
using System.Collections;
public class Elvesmoving : MonoBehaviour
{   
	float stopTime;//暂停时间	    
	float moveTime;//移动时间	    
	float vel_x, vel_y, vel_z;//速度	    
	/// <summary>	    
	/// 最大、最小飞行界限	    
	/// </summary>	    
	float maxPos_x = 9;	    
	float maxPos_y = 5;	    
	float minPos_x = -9;
	float minPos_y = -4;   
	float timeCounter1;//移动的计时器
	float timeCounter2;//暂停的计时器

	void Start()    
	{		        
		Change();	    
	}
	// Update is called once per frame
	void Update()
	{
		timeCounter1 += Time.deltaTime;
		//如果移动的计时器小于移动时间，则进行移动，否则暂停计时器累加，当暂停计时器大于暂停时间时，重置
		if (timeCounter1 < moveTime)
		{
			transform.Translate(vel_x, vel_y, 0, Space.Self);
			Checkmoving ();
		}
		else
		{
			timeCounter2 += Time.deltaTime;
			if (timeCounter2 > stopTime)
			{
				Change();
				timeCounter1 = 0;
				timeCounter2 = 0;
			}
		}
		Check();
	}
	//对参数赋值
	void Change()
	{
		stopTime = Random.Range(1, 2);
		moveTime = Random.Range(3, 8);
		vel_x = (float)(Random.Range(-8, 8)*0.01);
		vel_y = (float)(Random.Range(-8, 8)*0.01);
		if (Mathf.Abs (vel_x) <= 1e-6)
			vel_x = (float)(-4 * 0.01);
		if (Mathf.Abs (vel_y) <= 1e-6)
			vel_y = (float)(-4 * 0.01);
	}
	//判断是否进入移动死角
	void Checkmoving()
	{
		if (transform.localPosition.x >= 2.5 && transform.localPosition.x <= 2.6 && transform.localPosition.y>=2.5 && transform.localPosition.x<=2.6) {
			vel_x = (float)(-4*0.01);
			vel_y = (float)(-4*0.01);
		}
	}
	//判断是否达到边界，达到边界则将速度改为负的
	void Check()
	{
		//如果到达预设的界限位置值，调换速度方向并让它当前的坐标位置等于这个临界边的位置值
		if (transform.localPosition.x > maxPos_x)
		{
			vel_x = -vel_x;
			transform.localPosition = new Vector3(maxPos_x, transform.localPosition.y, 0);
		}
		if (transform.localPosition.x < minPos_x)
		{
			vel_x = -vel_x;
			transform.localPosition = new Vector3(minPos_x, transform.localPosition.y, 0);			   
		}
		if (transform.localPosition.y > maxPos_y)
		{
			vel_y = -vel_y;
			transform.localPosition = new Vector3(transform.localPosition.x, maxPos_y, 0);
		}
		if (transform.localPosition.y < minPos_y)
		{
			vel_y = -vel_y;
			transform.localPosition = new Vector3(transform.localPosition.x, minPos_y, 0);
		}
	}
}
