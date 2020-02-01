using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerCircle")
        {
            collision.gameObject.GetComponentInParent<BombContact>().DisableCircle();
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "playerTriangle")
        {
            collision.gameObject.GetComponentInParent<BombContact>().DisableTriangle();
            Destroy(this.gameObject);
        }
    }
}
