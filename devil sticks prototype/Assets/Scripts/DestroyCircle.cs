﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCircle : MonoBehaviour
{
    GameManager gm;
    PowerMeter pmScript;
    GameObject gameManager;
    public ParticleSystem redParticles;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        pmScript = gameManager.GetComponent<PowerMeter>();
        gm = gameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerCircle")
        {
            collision.gameObject.GetComponentInParent<PlayerAudioHandler>().PlaySound();
            Instantiate(redParticles, transform.position, Quaternion.identity);
            //add to player score
            gm.Addpoint();
            pmScript.GainMeter();
            //disable object
            gameObject.SetActive(false);
        }
    }
}
