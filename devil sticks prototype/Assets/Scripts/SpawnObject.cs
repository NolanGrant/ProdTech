using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
   
    float spawnTime = 3;
    float currentTime;
    public GameObject rotateObject;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if (Time.time > currentTime + spawnTime)
        {
            Instantiate(rotateObject, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            currentTime = Time.time;
        }
    }
}
