using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    public GameObject activeObstacle;

    float timer = 6;
    public float timeBetweenSpawns = 5f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > timeBetweenSpawns)
        {
            timer = 0;
            activeObstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }
    }
}
