using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPick : MonoBehaviour
{
    public GameObject Pistol;
    public GameObject SMG;
    public GameObject Pumpaction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "PistolD")
        {
            Pistol.gameObject.SetActive(true);
        }
        if (collision.gameObject.name == "SMGD")
        {
            SMG.gameObject.SetActive(true);
        }
       
        if (collision.gameObject.name == "ShotgunD")
        {
            Pumpaction.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "PistolD")
        {
            Pistol.gameObject.SetActive(false);
        }
        if (collision.gameObject.name == "SMGD")
        {
            SMG.gameObject.SetActive(false);
        }
        if (collision.gameObject.name == "ShotgunD")
        {
            Pumpaction.gameObject.SetActive(false);
        }
    }
}
