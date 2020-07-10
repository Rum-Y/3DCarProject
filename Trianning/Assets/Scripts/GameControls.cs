using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameControls : MonoBehaviour
{
    private GameObject car;
    public bool isStart =false;
    public bool isOver =false;
    private Text timeLabel,startLabel,bestLabel;
    private float time=0;
    private bool isGameCompleted=false;
    private GameObject[] carComputer;
    private string type =GAMETYPE.SINGLE.ToString();
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("Car");
        type =PlayerPrefs.GetString("GAMETYPE");
        if(type == GAMETYPE.SINGLE.ToString())
        {
           carComputer = GameObject.FindGameObjectsWithTag("CarComputer");
           foreach(GameObject item in carComputer)
           {
              item.SetActive(false);
           }
        }
        car = GameObject.FindGameObjectWithTag("Car");
        timeLabel=GameObject.Find("Time").GetComponent<Text>();
        startLabel=GameObject.Find("Start").GetComponent<Text>();
        bestLabel=GameObject.Find("Best").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameCompleted || this.name !="Finish")
        {
           return;
        }
        time+=Time.deltaTime;
        if(time<=2)
        startLabel.text="Ready";
        else
        if(time<=3)
        startLabel.text="Go";
        else
        {
            isStart=true;
            if(!isOver)
            {
               startLabel.text="";
               timeLabel.text=(Mathf.RoundToInt(time)-3).ToString();
            }
            else
            {
               if(type !=GAMETYPE.SINGLE.ToString())
               return;
               time=int.Parse(timeLabel.text);
               startLabel.text="Your Time"+timeLabel.text+"“ ";
               if(PlayerPrefs.HasKey("bestTime"))
               {
                  float best=PlayerPrefs.GetFloat("bestTime");
                  if(time<best)
                  {
                      PlayerPrefs.SetFloat("bestTime",Mathf.RoundToInt(time));
                      bestLabel.text="Your're the best";
                  }
                  else
                  {
                     bestLabel.text="Best Time:"+best+"“ ";
                  }
               }
               else
               {
	               bestLabel.text="Your're the best";
                   PlayerPrefs.SetFloat("bestTime",Mathf.RoundToInt(time));
               }
            	isGameCompleted=true;
            }  
        }
    }
    [HideInInspector]
    public int Rank=1;
    public void OnTriggerEnter(Collider other)
    {
    	if(other.gameObject.name == "Collider_Bottom")
    	{	
    		if(this.name == "Finish")
    		{
    			isOver=true;
    			if(PlayerPrefs.GetString("GAMETYPE") == GAMETYPE.SINGLE.ToString())
    			{

    			}
    			else
    			{
    				startLabel.text="Your Rank:"+Rank.ToString();
    			}
    		}
    		if(other.gameObject.name == "Collider_BottomComputer")
    		{
    			if(this.name =="Finish")
    			{
    				Rank++;
    			}
    		}
    	}
    }
}
