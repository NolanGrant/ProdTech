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
            collision.gameObject.GetComponentInParent<BombContact>().DisableCircle();
            Instantiate(bombParticles, transform.position, Quaternion.identity);
            pooler.Destroy(gameObject, 2);
        }

        if (collision.gameObject.tag == "playerTriangle")
        {
            collision.gameObject.GetComponentInParent<BombContact>().DisableTriangle();
            Instantiate(bombParticles, transform.position, Quaternion.identity);
            pooler.Destroy(gameObject, 2);
        }
    }
}
