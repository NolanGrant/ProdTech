using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    Rigidbody2D rb;
    GameManager gmScript;
    float currentSpeed;
    float setSpeed;
    float fastSpeed;
   

    // Start is called before the first frame update
    void Start()
    {
        gmScript = FindObjectOfType<GameManager>();
        fastSpeed = 8;
        setSpeed = 5;
        currentSpeed = setSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SpeedUp();
        MoveObject();
    }

    void SpeedUp()
    {
        //increase movement speed if game is sped up
        if (gmScript.increaseSpeed)
        {
            currentSpeed = fastSpeed;
        }
        else
        {
            currentSpeed = setSpeed;
        }
    }

    void MoveObject()
    {
        //move object left
        var hVelocity = rb.velocity;
        hVelocity.x = -currentSpeed;
        rb.velocity = hVelocity;
    }
}
