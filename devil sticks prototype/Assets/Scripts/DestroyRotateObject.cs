using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRotateObject : MonoBehaviour
{
    public GameObject triangle;
    public GameObject circle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triangle == null && circle == null)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.x <= -10)
        {
            Destroy(this.gameObject);
        }
    }
}
