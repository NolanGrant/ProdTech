using System.Collections;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
   
    float spawnTime;
    float currentTime;
    public GameObject[] rotateObjects;
    GameManager gmScript;
    int speedUpChance;

    float sequenceSpawnTime;
    int objectsBeforeSequence = 3;
    int CurrentObjsBeforeSequence;
    public int sequenceCount;
    int objectsSpawned;
    int sequenceChance;
    int addedRotation = 10;
    int directionMultiplier;
    Vector3 newRotation;
    bool sequenceStartable = false;
    bool firstObjectInSequence = false;
    public bool sequenceActive = false;

    float bombHeightSpawn;
    int bombChance;
    float bombTime;
    float currentBombTime;

    [Space(20)]
    public ObjectPooler pooler;

    // Start is called before the first frame update
    void Start()
    {
        gmScript = FindObjectOfType<GameManager>();
        CurrentObjsBeforeSequence = 0;
        objectsSpawned = 0;
        currentTime = Time.time;
        currentBombTime = Time.time;
        bombTime = Random.Range(6, 15);
    }

    // Update is called once per frame
    void Update()
    {
        TrackSpawnSpeed();
        Spawn();
        ManageBombSpawn();
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
            else if (!sequenceActive && sequenceChance != 1 && gmScript.increaseSpeed)
            {
                var _temp = pooler.Spawn(0);
                _temp.transform.position = transform.position;
                _temp.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
                if (!sequenceStartable && !sequenceActive)
                {
                    CurrentObjsBeforeSequence += 1;
                }
                currentTime = Time.time;
            }
            //chance spawn fast object
            else if (!sequenceActive && sequenceChance != 1 && !gmScript.increaseSpeed)
            {
                speedUpChance = Random.Range(0, 4);
                if (speedUpChance != 1)
                {
                    var _temp = pooler.Spawn(0);
                    _temp.transform.position = transform.position;
                    _temp.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
                    if (!sequenceStartable && !sequenceActive)
                    {
                        CurrentObjsBeforeSequence += 1;
                    }
                }
                else if (speedUpChance == 1)
                {
                    var _temp = pooler.Spawn(1);
                    _temp.transform.position = transform.position;
                    _temp.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
                    if (!sequenceStartable && !sequenceActive)
                    {
                        CurrentObjsBeforeSequence += 1;
                    }
                }
                currentTime = Time.time;
            }
            
            //sequence cannot start until certain amount of regular spawns have occurred
            if (CurrentObjsBeforeSequence >= objectsBeforeSequence)
            {
                sequenceStartable = true;
            }

            if (CurrentObjsBeforeSequence < objectsBeforeSequence)
            {
                sequenceStartable = false;
            }
        }
    }

    //spawn objects with increasing or decreasing rotation from the last
    IEnumerator SpawnSequence()
    {
        while (sequenceActive)
        {
            if (firstObjectInSequence)
            {
                GameObject newRotateObject = pooler.Spawn(0);
                newRotateObject.transform.position = transform.position;
                newRotateObject.transform.rotation = Quaternion.Euler(0, 0, newRotation.z + addedRotation * directionMultiplier);
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
                GameObject newRotateObject = pooler.Spawn(0);
                newRotateObject.transform.position = transform.position;
                newRotateObject.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
                objectsSpawned += 1;
            }

            if (objectsSpawned >= sequenceCount)
            {
                sequenceActive = false;
                firstObjectInSequence = false;
                CurrentObjsBeforeSequence = 0;
                currentTime = Time.time;
            }
            yield return new WaitForSeconds(sequenceSpawnTime);
        }
    }

    void TrackSpawnSpeed()
    {
        if (gmScript.increaseSpeed)
        {
            spawnTime = 2f;
            sequenceSpawnTime = 0.1f;
        }
        else
        {
            spawnTime = 3;
            sequenceSpawnTime = 0.2f;
        }
    }

    void SpawnBomb()
    {
        bombHeightSpawn = Random.Range(-1.9f, 1.91f);
        var _temp = pooler.Spawn(2);
        _temp.transform.position = new Vector3(transform.position.x, transform.position.y + bombHeightSpawn);
        _temp.transform.rotation = Quaternion.identity;
    }

    void ManageBombSpawn()
    {
        if (Time.time > currentBombTime + bombTime)
        {
            bombTime = Random.Range(6, 10);
            bombChance = Random.Range(0, 5);
            currentBombTime = Time.time;
            if (bombChance == 1)
            {
                SpawnBomb();
            }
        }
    }
}
