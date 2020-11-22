using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlayMainScene : MonoBehaviour
{
    AudioSource attackSound;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        attackSound = audios[0];
        attackSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
