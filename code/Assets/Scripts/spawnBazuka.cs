 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class spawnBazuka : MonoBehaviour
{
    public GameObject bazuka;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        Invoke();
    }
    
    void Invoke()
    {
        InvokeRepeating("SpawnBazuka", 0f, 5f);
    }

    void SpawnBazuka()
    {
        DetectedPlane dt;
        Vector3 pos = new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 0f), Random.Range(-10f, 10f));
        Instantiate(bazuka,pos, Quaternion.Euler(0, 0, 0));
    }
}
