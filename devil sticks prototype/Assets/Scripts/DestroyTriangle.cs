using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTriangle : MonoBehaviour
{
    GameManager gm;
    GameObject gameManager;
    public ParticleSystem blueParticles;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gm = gameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerTriangle")
        {
            Instantiate(blueParticles, transform.position, Quaternion.identity);
            gm.Addpoint();
            Destroy(this.gameObject);
        }
    }
}
