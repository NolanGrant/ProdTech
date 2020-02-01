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

    public List<GameObject> _children;

    public GameObject Spawn(int _pool)
    {
        if (pools[_pool].objects.Count > 0)
        {
            var _temp = pools[_pool].objects[0];
            pools[_pool].objects.Remove(_temp);
            foreach (GameObject _object in GetChildrenOf(_temp))
            {
                _object.SetActive(true);
            }
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

        foreach (GameObject _object in GetChildrenOf(_victim))
        {
            _object.SetActive(false);
        }
        _victim.SetActive(false);
        pools[_pool].objects.Add(_victim);
    }

    private List<GameObject> GetChildrenOf(GameObject _parent)
    {

        _children = new List<GameObject>();

        foreach (Transform child in transform)
        {
            _children.Add(child.gameObject);
        }

        return _children;
    }
}
