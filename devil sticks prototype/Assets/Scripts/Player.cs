using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidbody2D;
    public float rotationForce;
    public float brakeDrag = .8f;

    public enum MovementMethod { setVelocityNoBrake, setVelocityWithBrake, addTorque }
    public MovementMethod movementMethod;

    public float angleThreshold = 15f;
    public float distanceThreshold = 1f;

    public ObstacleManager obstacleManager;

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
        if (Input.GetButton("CW") && Input.GetButton("CCW") == false)
        {
            print("cw");
            RotatePlayer(-1);
        }
        if (Input.GetButton("CCW") && Input.GetButton("CW") == false)
        {
            print("ccw");
            RotatePlayer(1);
        }
        if(Input.GetButton("CCW") == true && Input.GetButton("CW") == true)
        {
            //brake
            myRigidbody2D.angularVelocity *= (1 - Time.fixedDeltaTime * brakeDrag);
        }
        else if (Input.GetButton("CW") == false && Input.GetButton("CCW") == false && movementMethod == MovementMethod.setVelocityWithBrake)
        {
            RotatePlayer(0);
        }


    }

    private void FixedUpdate()
    {

        if (obstacleManager.activeObstacle != null)
        {
            if (Vector2.Angle(obstacleManager.activeObstacle.transform.up, transform.up) < angleThreshold)
            {
                Debug.DrawLine(transform.position, obstacleManager.activeObstacle.transform.position, Color.green);
            }
            else
            {
                Debug.DrawLine(transform.position, obstacleManager.activeObstacle.transform.position, Color.magenta);
            }
        }
        Debug.DrawLine(transform.position, transform.position + transform.right * distanceThreshold, Color.white);

        if (obstacleManager.activeObstacle != null)
        {
            if (Vector2.Angle(obstacleManager.activeObstacle.transform.up, transform.up) < angleThreshold && Vector2.Distance(myRigidbody2D.position, obstacleManager.activeObstacle.transform.position) < distanceThreshold)
            {
                Destroy(obstacleManager.activeObstacle);
            }
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
