using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public ParticleSystem bombParticles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerCircle")
        {
            collision.gameObject.GetComponentInParent<BombContact>().DisableCircle();
            Instantiate(bombParticles, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "playerTriangle")
        {
            collision.gameObject.GetComponentInParent<BombContact>().DisableTriangle();
            Instantiate(bombParticles, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
