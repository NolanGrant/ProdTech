using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string name;
    public GameObject prefab;
    public List<GameObject> objects;

}

public class ObjectPooler : MonoBehaviour
{

    public Pool[] pools;


    public GameObject Spawn(int _pool)
    {
        if (pools[_pool].objects.Count > 0)
        {
            var _temp = pools[_pool].objects[0];
            pools[_pool].objects.Remove(_temp);
            _temp.SetActive(true);
            return _temp;
        }
        else
        {
            return Instantiate(pools[_pool].prefab);

        }
    }

    public void Destroy(GameObject _victim, int _pool)
    {
        _victim.SetActive(false);
        pools[_pool].objects.Add(_victim);
    }

}
