using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageBazuka : MonoBehaviour
{
    
    public float bHealth = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float dmg)
    {
        bHealth = bHealth - dmg;
        if(bHealth<=0)
        {
            gameObject.GetComponent<Animator>().Play("Death");
            Destroy(gameObject, 1.2f);
            

           
        }
    }
}
