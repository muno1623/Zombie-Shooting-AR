using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class SurvivalTime : MonoBehaviour
{
    public Stopwatch timer;
    GameObject house;
    float initialTime;
    bool chkTimer = true;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        timer = new Stopwatch();
       

    }

    // Update is called once per frame
    void Update()
    {
        house = GameObject.Find("ruined_house");
        if (house.name == "ruined_house" && chkTimer == true)
        {
            timer.Start();
            chkTimer = false;
        }
        if (house.name == "ruined_house")
        {
            

            int sec = (int)Mathf.Round(timer.Elapsed.Seconds);
            int hour = timer.Elapsed.Hours;
            int min = timer.Elapsed.Minutes;
            if (sec >= 10)
            {
                text.text = min + ":" + sec;
            }
            if (sec < 10)
            {
                text.text = min + ":0" + sec;
            }
        }
    
        
        

            
        
    }
}

