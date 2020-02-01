using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRotateObject : MonoBehaviour
{
    public GameObject triangle;
    private GameObject _triangle;
    public GameObject circle;
    private GameObject _circle;
    GameObject gameManager;
    PowerMeter pmScript;

    [Space(20)]
    public ObjectPooler pooler;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmScript = gameManager.GetComponent<PowerMeter>();
        pooler = GameObject.FindGameObjectWithTag("pooler").GetComponent<ObjectPooler>();
        _triangle = triangle;
        _circle = circle;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -10)
        {
            if (triangle = null)
            {
                pmScript.DrainMeter();
            }

            if (circle = null)
            {
                pmScript.DrainMeter();
            }

            pooler.Destroy(gameObject, 0);
            triangle = _triangle;
            circle = _circle;
        }
        else
        {
            if (triangle == null && circle == null)
            {
                pooler.Destroy(gameObject, 0);
                triangle = _triangle;
                circle = _circle;
            }
        }
    }
}
