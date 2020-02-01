using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    GameManager gmScript;
    Rigidbody2D rb;
    public ParticleSystem greenParticles;
    float currentSpeed = 5;

    [Space(20)]
    public ObjectPooler pooler;

    // Start is called before the first frame update
    void Start()
    {
        pooler = GameObject.FindGameObjectWithTag("pooler").GetComponent<ObjectPooler>();
        rb = GetComponent<Rigidbody2D>();
        gmScript = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
        DestroyAfterDistance();
    }

    void MoveObject()
    {
        var hVelocity = rb.velocity;
        hVelocity.x = -currentSpeed;
        rb.velocity = hVelocity;
    }

    void DestroyAfterDistance()
    {
        if (transform.position.x <= -10)
        {
            pooler.Destroy(gameObject, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerCircle" || collision.gameObject.tag == "playerTriangle")
        {
            collision.gameObject.GetComponentInParent<PlayerAudioHandler>().PlaySound();
            Instantiate(greenParticles, transform.position, Quaternion.identity);
            gmScript.SpeedUp();
            gameObject.SetActive(false);
        }
    }
}
