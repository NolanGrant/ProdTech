using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
   
    float spawnTime = 3;
    float currentTime;
    public GameObject rotateObject;

    int objectsBeforeSequence = 3;
    int CurrentObjsBeforeSequence;
    public int sequenceCount;
    public int objectsSpawned;
    int sequenceChance;
    int addedRotation = 10;
    public int directionMultiplier;
    Vector3 newRotation;
    bool sequenceStartable = false;
    bool firstObjectInSequence = false;
    public bool sequenceActive = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentObjsBeforeSequence = 0;
        objectsSpawned = 0;
        currentTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if (Time.time > currentTime + spawnTime && !sequenceActive)
        {
            
            //50 50 chance to start sequence
            sequenceChance = Random.Range(0, 2);
            //start the sequence spawn
            if (sequenceChance == 1 && sequenceStartable)
            {
                sequenceStartable = false;
                CurrentObjsBeforeSequence = 0;
                sequenceActive = true;
                firstObjectInSequence = false;
                StartCoroutine(SpawnSequence());
            }
            //spawn regular 
            else if (!sequenceActive && sequenceChance != 1)
            {
                Instantiate(rotateObject, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
                currentTime = Time.time;
            }
            
            if (!sequenceStartable && !sequenceActive)
            {
                CurrentObjsBeforeSequence += 1;
            }
            //sequence cannot start until certain amount of regular spawns have occurred
            if (CurrentObjsBeforeSequence >= objectsBeforeSequence)
            {
                sequenceStartable = true;
            }
        }
    }

    IEnumerator SpawnSequence()
    {
        while (sequenceActive)
        {
            if (firstObjectInSequence)
            {
                GameObject newRotateObject = Instantiate(rotateObject as GameObject, transform.position, Quaternion.Euler(0, 0, newRotation.z + addedRotation * directionMultiplier));
                newRotation = newRotateObject.transform.rotation.eulerAngles;
                objectsSpawned += 1;
            }

            if (!firstObjectInSequence)
            {
                directionMultiplier = Random.Range(-1, 1);
                if (directionMultiplier != -1)
                {
                    directionMultiplier = 1;
                }
                sequenceCount = Random.Range(5, 21);
                objectsSpawned = 0;
                firstObjectInSequence = true;
                GameObject newRotateObject = Instantiate(rotateObject as GameObject, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
                newRotation = newRotateObject.transform.rotation.eulerAngles;
                objectsSpawned += 1;
            }

            if (objectsSpawned >= sequenceCount)
            {
                sequenceActive = false;
                firstObjectInSequence = false;
                currentTime = Time.time;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
