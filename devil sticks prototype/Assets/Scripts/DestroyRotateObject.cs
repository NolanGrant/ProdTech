using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRotateObject : MonoBehaviour
{
    public GameObject triangle;
    public GameObject circle;
    GameObject gameManager;
    PowerMeter pmScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmScript = gameManager.GetComponent<PowerMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triangle == null && circle == null)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.x <= -10 && triangle != null && circle != null)
        {
            pmScript.DrainMeter();
            pmScript.DrainMeter();
            Destroy(this.gameObject);
        }
        else if (transform.position.x <= -10 && triangle == null && circle != null)
        {
            pmScript.DrainMeter();
            Destroy(this.gameObject);
        }
        else if (transform.position.x <= -10 && triangle != null && circle == null)
        {
            pmScript.DrainMeter();
            Destroy(this.gameObject);
        }
    }
}
