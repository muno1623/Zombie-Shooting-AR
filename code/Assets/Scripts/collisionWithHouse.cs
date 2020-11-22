using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionWithHouse : MonoBehaviour
{
    public bool zombie;
    float timer;
    int timeBwAttack;
    private GameControllerScript gameController;
    AudioSource attackSound;
    // Start is called before the first frame update
    void Start()
    {
        timeBwAttack = 2;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameControllerScript>();
        }
        AudioSource[] audios = GetComponents<AudioSource>();
        attackSound = audios[0];

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (zombie && timer >= timeBwAttack)
        {
            Attack();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "house")
        {
            zombie = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "house")
        {
            zombie = false;
            gameController.darkScreen.SetActive(false);
        }
    }
    void Attack()
    {
        
        
        timer = 0;
        GetComponent<Animator>().Play("Z_Attack");
        gameController.zombieAttack(zombie);
        attackSound.Play();
        
        
    }
}
