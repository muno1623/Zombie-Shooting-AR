using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore;
using GoogleARCore.Examples.Common;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;




public class shootBazuka : MonoBehaviour
{
    public Text text;
    public Button shoot;
    public Camera cam;
    public float dmg = 10f;
    public float HeadShot = 30f;
    AudioSource shootS;
    AudioSource reloadS;
    public GameObject BloodEf;
    public Text ammoT1;
    public Text ammoT2;
    public int ammo1;
    public int ammo2;
    public bool ammoEmpty;
    public ParticleSystem flash;
    public GameObject pistol;
    public bool reloadChk;
    RaycastHit hit;



    // Start is called before the first frame update
    public void Start()
    {
        pistol.GetComponent<Animator>().SetTrigger("reload");
        shoot.onClick.AddListener(onShoot);
        AudioSource[] audio = GetComponents<AudioSource>();
        shootS = audio[0];
        reloadS = audio[1];
        reloadS.Play();

        ammo1 = 10;
        ammo2 = 50;
        reloadChk = true;


    }

    // Update is called once per frame
    public void Update()
    {
       
    }
    public void ammoRefill()
    {
        ammo1 = 10;
        ammo2 = 50;
        ammoT1.text = "10";
        ammoT2.text = "/ 50";
        ammoEmpty = false;
        reloadChk = true;
    }

    IEnumerator wait4reload()
    {
        yield return new WaitForSeconds(3f);
        reloadChk = true;
    }

    void onShoot()
    {
        
        if (!ammoEmpty && reloadChk)
        {
            if (ammo1 == 1)
            {
                ammo1 = 11;
                pistol.GetComponent<Animator>().SetTrigger("reload");
                reloadChk = false;
                StartCoroutine(wait4reload());
                reloadS.Play();
                
            }

            ammo1 = ammo1 - 1;
            string a1Str = (ammo1).ToString();
            ammoT1.text = a1Str;

            ammo2 = ammo2 - 1;
            string a2Str = (ammo2).ToString();
            ammoT2.text = "/ " + a2Str;

            if (ammo2 == 0)
            {
                ammoEmpty = true;
                ammo1 = 0;
                string a11Str = (ammo1).ToString();
                ammoT1.text = a11Str;
            }

            shootS.Play();
            

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                if(hit.transform.gameObject.tag ==  "Zombie")
                {
                    damageZombie dz = hit.transform.GetComponent<damageZombie>();
                    if (dz != null)
                    {
                        dz.TakeDamage(dmg);
                        GameObject bf = Instantiate(BloodEf, hit.point, Quaternion.LookRotation(hit.normal));
                        Destroy(bf, 0.2f);
                    }

                }
                
                if (hit.transform.gameObject.tag == "Titan")
                {
                    Debug.LogError(hit.transform.gameObject.tag.ToString());
                    damageBazuka db = hit.transform.GetComponent<damageBazuka>();
                    if (db != null)
                    {
                        db.TakeDamage(dmg);
                        GameObject bf = Instantiate(BloodEf, hit.point, Quaternion.LookRotation(hit.normal));
                        Destroy(bf, 0.2f);
                        
                    }
                }

            }
            flash.Play();
            pistol.GetComponent<Animator>().Play("Shoot");
        }
        



    }
}
