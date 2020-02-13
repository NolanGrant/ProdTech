using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public ParticleSystem bombParticles;

    [Space(20)]
    public ObjectPooler pooler;
    private void Start()
    {
        pooler = GameObject.FindGameObjectWithTag("pooler").GetComponent<ObjectPooler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerCircle")
        {
            //disable the player's circle if contact is made
            collision.gameObject.GetComponentInParent<BombContact>().DisableCircle();
            Instantiate(bombParticles, transform.position, Quaternion.identity);
            //send bomb back to pool
            pooler.Destroy(gameObject, 2);
        }

        if (collision.gameObject.tag == "playerTriangle")
        {
            //disable the player's triangle if contact is made
            collision.gameObject.GetComponentInParent<BombContact>().DisableTriangle();
            Instantiate(bombParticles, transform.position, Quaternion.identity);
            //send bomb back to pool
            pooler.Destroy(gameObject, 2);
        }
    }
}
