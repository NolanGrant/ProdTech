using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRotateObject : MonoBehaviour
{
    public GameObject triangle;
    public GameObject circle;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (triangle == null && circle == null)
        {
            pooler.Destroy(gameObject, 0);
        }

        if (transform.position.x <= -10 && triangle != null && circle != null)
        {
            pmScript.DrainMeter();
            pmScript.DrainMeter();
            pooler.Destroy(gameObject, 0);
        }
        else if (transform.position.x <= -10 && triangle == null && circle != null)
        {
            pmScript.DrainMeter();
            pooler.Destroy(gameObject, 0);
        }
        else if (transform.position.x <= -10 && triangle != null && circle == null)
        {
            pmScript.DrainMeter();
            pooler.Destroy(gameObject, 0);
        }
    }
}
