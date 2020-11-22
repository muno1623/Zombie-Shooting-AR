using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionWithCamera : MonoBehaviour
{
    public bool bazuka;
    float timer;
    int timeBwAttack;
    private GameControllerScript gameController;
    AudioSource attackSound;
    // Start is called before the first frame update
    void Start()
    {
        timeBwAttack = 2;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameControllerScript>();
        }
        AudioSource[] audios = GetComponents <AudioSource>();
        attackSound = audios[0];

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(bazuka && timer >= timeBwAttack)
        {
            Attack();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "MainCamera")
        {
            bazuka = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            bazuka = false;
        }
    }
    void Attack()
    {
        timer = 0;
        GetComponent<Animator>().Play("Attack(2)");
        gameController.bazukaAttack(bazuka);
        attackSound.Play();
    }

    

}
