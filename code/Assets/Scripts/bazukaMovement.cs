using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bazukaMovement : MonoBehaviour
{
    bool bazuka = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MainCamera")
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
    // Update is called once per frame
    void Update()
    {
        if (bazuka == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 0.4f);
            transform.LookAt(Camera.main.transform.position);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
        else if (bazuka == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 0f);
            transform.LookAt(Camera.main.transform.position);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }
}
