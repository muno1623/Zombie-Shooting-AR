using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageZombie : MonoBehaviour
{
    public float zHealth = 30f;
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
        zHealth = zHealth - dmg;
        if (zHealth <= 0)
        {
            gameObject.GetComponent<Animator>().Play("Z_FallingBack");
            Destroy(gameObject, 1.2f);



        }
    }
}
