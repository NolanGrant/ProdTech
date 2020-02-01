using System;
using System.Collections.Generic;
using UnityEngine;

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
