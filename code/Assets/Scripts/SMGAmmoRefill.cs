using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGAmmoRefill : MonoBehaviour
{
    SMGShoot script2;
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
                        script2 = GetComponent<SMGShoot>();
                        script2.ammoRefill();
                        script2.smg.GetComponent<Animator>().SetTrigger("reload");
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
