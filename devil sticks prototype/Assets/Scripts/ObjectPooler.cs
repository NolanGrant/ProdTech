using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct obstacle
{
    public int index;
    public GameObject pivot;
    public bool onDisplay;
    public float XPos;
    public float angle;
    public float rotationSpeed;
    public GameObject triangle, circle;

}

public class ObjectPooler : MonoBehaviour
{

    public GameObject obstaclePrefab;
    public List<GameObject> cachedObstacles;
    public GameObject nextObstacle;

    public GameObject Spawn()
    {
        if (cachedObstacles.Count > 0)
        {
            var _temp = cachedObstacles[0];
            cachedObstacles.Remove(_temp);
            _temp.SetActive(true);
            return _temp;
        }
        else
        {
            return Instantiate(obstaclePrefab);

        }
    }

    public void Destroy(GameObject _victim)
    {
        _victim.SetActive(false);
        cachedObstacles.Add(_victim);
    }

}
