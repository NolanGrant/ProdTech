﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTriangle : MonoBehaviour
{
    GameManager gm;
    PowerMeter pmScript;
    GameObject gameManager;
    public ParticleSystem blueParticles;

    [Space(20)]
    public ObjectPooler pooler;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmScript = gameManager.GetComponent<PowerMeter>();
        gm = gameManager.GetComponent<GameManager>();
        pooler = GameObject.FindGameObjectWithTag("pooler").GetComponent<ObjectPooler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerTriangle")
        {
            collision.gameObject.GetComponentInParent<PlayerAudioHandler>().PlaySound();
            Instantiate(blueParticles, transform.position, Quaternion.identity);
            gm.Addpoint();
            pmScript.GainMeter();
            gameObject.SetActive(false);
        }
    }
}
