using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore;
using GoogleARCore.Examples.Common;
using UnityEngine.EventSystems;

public class ammoRefill : MonoBehaviour
{
    shootBazuka script1;
    GameControllerScript gcs;
    // Start is called before the first frame update
    void Start()
    {
        //ammo.onClick.AddListener(onShoot);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {

            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.name == "AmmoBox")
                    {
                        script1 = GetComponent<shootBazuka>();
                        script1.ammoRefill();
                        script1.pistol.GetComponent<Animator>().SetTrigger("reload");
                    }
                    else if (hit.collider.name == "Aid")
                    {
                        gcs = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
                        gcs.updateHealth();
                    }
                }
            }
                
            
        }
    }
}
