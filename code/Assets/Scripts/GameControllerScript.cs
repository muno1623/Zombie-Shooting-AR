using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameControllerScript : MonoBehaviour
{
    public GameObject HouseImage;
    public GameObject HealthImage;
    GameObject timer;
    private SurvivalTime st;
    Scene sceneName;
    public Text surTimeText;
    public Text timeText;
    GameObject house;
    public GameObject explosion;
    public GameObject darkScreen;
    public GameObject gameOver;
    public GameObject bloodScreen;
    public Text healthText;
    int health;
    public Text houseHealthText;
    int houseHealth;
    AudioSource explodeSound;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.FindWithTag("Timer");
        if (timer != null)
        {
            st = timer.GetComponent<SurvivalTime>();
        }
        sceneName = SceneManager.GetActiveScene();
        AudioSource[] audio = GetComponents<AudioSource>();
        explodeSound = audio[0];
        health = 100;
        houseHealth = 100;
    }

    // Update is called once per frame
    public void Update()
    {
        house = GameObject.Find("ruined_house");
        if (health <= 0)
        {
            if (sceneName.name == "BeatTheClock")
            {
                HealthImage.gameObject.SetActive(false);
                HouseImage.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                StartCoroutine(Wait2secondsforGameOver());
            }
            else if (sceneName.name == "Survival")
            {
                HealthImage.gameObject.SetActive(false);
                HouseImage.gameObject.SetActive(false);
                st.timer.Stop();
                //gameOver.gameObject.SetActive(true);
                surTimeText.gameObject.SetActive(true);
                surTimeText.text = "You Survived : " + timeText.text;
                StartCoroutine(Wait2secondsforGameOver());
            }
        }
        if (houseHealth <= 0)
        {
            if (sceneName.name == "BeatTheClock")
            {
                explodeSound.Play();
                HealthImage.gameObject.SetActive(false);
                HouseImage.gameObject.SetActive(false);
                
                GameObject bf = Instantiate(explosion, house.transform.position, house.transform.rotation);
                Destroy(bf, 2f);
                gameOver.gameObject.SetActive(true);
                StartCoroutine(Wait2secondsforGameOver());
            }
            else if (sceneName.name == "Survival")
            {
                explodeSound.Play();
                HealthImage.gameObject.SetActive(false);
                HouseImage.gameObject.SetActive(false);
                st.timer.Stop();
                
                GameObject bf = Instantiate(explosion, house.transform.position, house.transform.rotation);
                Destroy(bf, 2f);
                //gameOver.gameObject.SetActive(true);
                surTimeText.gameObject.SetActive(true);
                surTimeText.text = "You Survived : " + timeText.text;
                StartCoroutine(Wait2secondsforGameOver());
            }


        }

    }
    public void updateHealth()
    {


        health = 100;
        healthText.text = "100";


    }
    public void zombieAttack(bool zombie)
    {
        darkScreen.gameObject.SetActive(true);
        //StartCoroutine(Wait2seconds2());
        houseHealth = houseHealth - 5;
        string h = houseHealth.ToString();
        houseHealthText.text = "" + h;

    }
    public void bazukaAttack(bool bazuka)
    {
        bloodScreen.gameObject.SetActive(true);
        StartCoroutine(Wait2seconds());
        health = health - 10;
        string h = health.ToString();
        healthText.text = "" + h;

    }

    IEnumerator Wait2seconds()
    {
        yield return new WaitForSeconds(2f);
        bloodScreen.gameObject.SetActive(false);
    }
    IEnumerator Wait2seconds2()
    {
        yield return new WaitForSeconds(2f);

    }
    IEnumerator Wait2secondsforGameOver()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");

    }

}
