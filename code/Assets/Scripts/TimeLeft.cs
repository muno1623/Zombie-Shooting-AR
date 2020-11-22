using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLeft : MonoBehaviour
{
    GameObject house;
    public GameObject t1;
    public GameObject t2;
    public GameObject win;
    float timeLeft = 60.0f;
    int sec;
    int Min;

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        house = GameObject.Find("ruined_house");
        if (house.name == "ruined_house")
        {


            timeLeft -= Time.deltaTime;
            sec = (int)(timeLeft % 60);
            Min = (int)timeLeft / 60;
            if (sec >= 10)
            {
                text.text = Min + ":" + sec;
            }
            if (sec < 10)
            {
                text.text = Min + ":0" + sec;
            }
            if (timeLeft < 0)
            {
                t1.gameObject.SetActive(false);
                t2.gameObject.SetActive(false);
                win.gameObject.SetActive(true);
                StartCoroutine(Wait2seconds());

            }
        }
    }
    IEnumerator Wait2seconds()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainMenu");
        win.gameObject.SetActive(false);
    }
}
