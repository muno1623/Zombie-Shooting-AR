using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovements : MonoBehaviour
{
    GameObject house;
    bool zombie = false;
    // Start is called before the first frame update
    void Start()
    {

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
        }
    }
    // Update is called once per frame
    void Update()
    {
        house = GameObject.Find("ruined_house");
        if (zombie == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 1f);
            transform.LookAt(house.transform.position);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
        else if (zombie == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 0f);
            transform.LookAt(house.transform.position);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }
}
