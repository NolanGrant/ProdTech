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

public class SpawnerPooler : MonoBehaviour
{
    private float fixedY;
    private Camera mainCamera;
    [Header("Pooler Settings")]
    [Space(8)]
    public int cachedPrefabs;
    [Space(2)]
    [Tooltip("Between triangle and the circle")]
    public float spawnDistance;
    public float distanceToPlayer;
    private float spawnAngle;
    [Space(2)]
    public GameObject triangle, circle;
    public GameObject obstacleTransformPrefab;
    [Space(2)]
    public List<obstacle> cachedObstacles;
    [Space(12)]

    [Header("Spawner Settings")]
    [Space(8)]
    public obstacle nextObstacle;

    private void Start()
    {
        //fill the pool
        FillThePool(cachedPrefabs);
        PlaceObstacle(UnityEngine.Random.Range(0, 360), distanceToPlayer, 0f);
        mainCamera = Camera.main;
        fixedY = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 0)).x;
    }

    public void PlaceObstacle(float _angle, float _distance, float _rotSpeed)
    {
        var _obstacle = nextObstacle;
        _obstacle.pivot.transform.position = new Vector3(_distance, fixedY, -3f);
        _obstacle.triangle.transform.localPosition = new Vector3(0, spawnDistance / 2, 0);
        _obstacle.circle.transform.localPosition = new Vector3(0, -spawnDistance / 2, 0);
        _obstacle.angle = _angle;
        _obstacle.pivot.transform.Rotate(new Vector3(0, 0, _angle));
        _obstacle.triangle.SetActive(true);
        _obstacle.circle.SetActive(true);

    }

    private void FillThePool(int _no)
    {

        for (int i = 0; i < _no; i++)
        {
            CreateObstacle();
        }

        PickNextObstacle();//pick next available obstacle to be revived
    }

    private void PickNextObstacle()
    {
        if (cachedObstacles.Count > 0)
        {
            nextObstacle = cachedObstacles[0];
        }
        else
        {
            CreateObstacle();
            PickNextObstacle();
        }
    }

    private void CreateObstacle()
    {
        var _obstacle = new obstacle();
        _obstacle.pivot = Instantiate(obstacleTransformPrefab);
        _obstacle.index = cachedObstacles.Count - 1;

        _obstacle.onDisplay = false;

        if (triangle != null)
        {
            _obstacle.triangle = Instantiate(triangle);
            _obstacle.triangle.SetActive(false);
            _obstacle.triangle.transform.SetParent(_obstacle.pivot.transform);
        }

        if (circle != null)
        {
            _obstacle.circle = Instantiate(circle);
            _obstacle.circle.SetActive(false);
            _obstacle.circle.transform.SetParent(_obstacle.pivot.transform);
        }

        _obstacle.XPos = 0f;
        _obstacle.angle = 0f;
        _obstacle.rotationSpeed = 0f;
        cachedObstacles.Add(_obstacle);
    }
}
