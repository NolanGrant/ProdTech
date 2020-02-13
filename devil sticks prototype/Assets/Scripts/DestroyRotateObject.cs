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
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -10)
        {
            if (triangle.activeSelf)
            {
                //damage player health
                pmScript.DrainMeter();
            }
            if (circle.activeSelf)
            {
                //damage player health
                pmScript.DrainMeter();
            }
            
            //send object to pool 
            pooler.Destroy(gameObject, 0);
        }
        else
        {
            //send object to pool if circle and triangle were hit
            if (!triangle.activeSelf && !circle.activeSelf)
            {
                pooler.Destroy(gameObject, 0);
            }
        }
    }
}
