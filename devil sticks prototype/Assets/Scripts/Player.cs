using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidbody2D;
    public float rotationForce;

    public enum MovementMethod { setVelocityNoBrake, setVelocityWithBrake, addTorque }
    public MovementMethod movementMethod;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("CW"))
        {
            print("cw");
            RotatePlayer(-1);
        }
        if (Input.GetButton("CCW"))
        {
            print("ccw");
            RotatePlayer(1);
        }
        else if (Input.GetButton("CW") == false && Input.GetButton("CCW") == false && movementMethod == MovementMethod.setVelocityWithBrake)
        {
            RotatePlayer(0);
        }
    }

    void RotatePlayer(int rotationDirection)
    {
        print("rotating");
        if (movementMethod == MovementMethod.addTorque)
        {
            myRigidbody2D.AddTorque((float)rotationDirection * rotationForce * Time.deltaTime, ForceMode2D.Force);
        }
        else if (movementMethod == MovementMethod.setVelocityNoBrake)
        {
            myRigidbody2D.angularVelocity = (float)rotationDirection * rotationForce;
        }

        else if (movementMethod == MovementMethod.setVelocityWithBrake)
        {
            myRigidbody2D.angularVelocity = (float)rotationDirection * rotationForce;
        }
    }
}
