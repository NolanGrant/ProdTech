using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
<<<<<<< HEAD
    // Start is called before the first frame update
    void Start()
    {
        
=======
    float fastRotate;
    float setRotate;
    bool rotateFaster = false;
    Player playerScript;
    GameManager gmScript;

    // Start is called before the first frame update
    void Start()
    {
        gmScript = FindObjectOfType<GameManager>();
        playerScript = GetComponent<Player>();
        setRotate = playerScript.rotationForce;
        fastRotate = playerScript.rotationForce * 5;
>>>>>>> NathanSpeedTest
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        
=======
        RotateFast();
    }

    void RotateFast()
    {
        if (gmScript.increaseSpeed && !rotateFaster)
        {
            playerScript.rotationForce = fastRotate;
            rotateFaster = true;
        }

        if (!gmScript.increaseSpeed && rotateFaster)
        {
            playerScript.rotationForce = setRotate;
            rotateFaster = false;
            return;
        }
>>>>>>> NathanSpeedTest
    }
}
