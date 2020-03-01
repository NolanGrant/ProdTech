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

    //public ObstacleManager obstacleManager;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    Coroutine cwDetectFastButtonReleaseCoroutine = null;
    Coroutine ccwDetectFastButtonReleaseCoroutine = null;

    // Update is called once per frame
    void Update()
    {
        //boost detection
        if (Input.GetButtonDown("CW"))
        {
            if (cwDetectFastButtonReleaseCoroutine == null)
            {
                cwDetectFastButtonReleaseCoroutine = StartCoroutine(DetectFastButtonRelease("CW"));
            }
            else
            {
                StopCoroutine(cwDetectFastButtonReleaseCoroutine);
                cwDetectFastButtonReleaseCoroutine = StartCoroutine(DetectFastButtonRelease("CW"));  
            }
        }
        if (Input.GetButtonDown("CCW"))
        {
            //print("ccw");
            if (ccwDetectFastButtonReleaseCoroutine == null)
            {
                ccwDetectFastButtonReleaseCoroutine = StartCoroutine(DetectFastButtonRelease("CCW"));
            }
            else
            {
                StopCoroutine(ccwDetectFastButtonReleaseCoroutine);
                ccwDetectFastButtonReleaseCoroutine = StartCoroutine(DetectFastButtonRelease("CCW"));
            }
        }

        //rotate clockwise
        if (Input.GetButton("CW") && Input.GetButton("CCW") == false)
        {
            //print("cw");
            RotatePlayer(-1, ForceMode2D.Force);
        }
        //rotate counter clockwise
        if (Input.GetButton("CCW") && Input.GetButton("CW") == false)
        {
            //print("ccw");
            RotatePlayer(1, ForceMode2D.Force);
        }
        //when pushing both buttons, brake the rotation
        if (Input.GetButton("CCW") == true && Input.GetButton("CW") == true)
        {
            //brake rotation using drag method
            print("braking");
            myRigidbody2D.angularVelocity *= (1 - Time.fixedDeltaTime * brakeDrag);
        }
        else if (Input.GetButton("CW") == false && Input.GetButton("CCW") == false && movementMethod == MovementMethod.setVelocityWithBrake)
        {
            RotatePlayer(0, ForceMode2D.Force);
        }
    }

    public float maximumTimeToReleaseButtonToRecieveBoost = .5f;
    public float boostForce = 10f;
    IEnumerator DetectFastButtonRelease(string button)
    {
        float timeSincePress = 0;

        while (timeSincePress < maximumTimeToReleaseButtonToRecieveBoost)
        {
            timeSincePress += Time.deltaTime;
            if (Input.GetButtonUp(button))
            {
                //apply boost
                if (button == "CW")
                {
                    RotatePlayer(-boostForce, ForceMode2D.Impulse);
                }
                if (button == "CCW")
                {
                    RotatePlayer(boostForce, ForceMode2D.Impulse);
                }
                print("apply boost");
                break;
            }

            yield return null;
        }
    }

    private void FixedUpdate()
    {

        //if (obstacleManager.activeObstacle != null)
        //{
        //    if (Vector2.Angle(obstacleManager.activeObstacle.transform.up, transform.up) < angleThreshold)
        //    {
        //        Debug.DrawLine(transform.position, obstacleManager.activeObstacle.transform.position, Color.green);
        //    }
        //    else
        //    {
        //        Debug.DrawLine(transform.position, obstacleManager.activeObstacle.transform.position, Color.magenta);
        //    }
        //}
        //Debug.DrawLine(transform.position, transform.position + transform.right * distanceThreshold, Color.white);

        //if (obstacleManager.activeObstacle != null)
        //{
        //    if (Vector2.Angle(obstacleManager.activeObstacle.transform.up, transform.up) < angleThreshold && Vector2.Distance(myRigidbody2D.position, obstacleManager.activeObstacle.transform.position) < distanceThreshold)
        //    {
        //        Destroy(obstacleManager.activeObstacle);
        //    }
        //}

        print(myRigidbody2D.angularVelocity);
        if (Mathf.Abs(myRigidbody2D.angularVelocity) > maxRotationSpeed)
        {
            print("speed capped");
            myRigidbody2D.angularVelocity = Mathf.Sign(myRigidbody2D.angularVelocity) * maxRotationSpeed; 
        }
    }

    public float maxRotationSpeed = 1f;

    void RotatePlayer(float rotationDirection, ForceMode2D forceType)
    {
        //print("rotating");
        if (movementMethod == MovementMethod.addTorque)
        {
            myRigidbody2D.AddTorque(rotationDirection * rotationForce * Time.deltaTime, forceType);
        }
        else if (movementMethod == MovementMethod.setVelocityNoBrake)
        {
            myRigidbody2D.angularVelocity = rotationDirection * rotationForce;
        }

        else if (movementMethod == MovementMethod.setVelocityWithBrake)
        {
            myRigidbody2D.angularVelocity = rotationDirection * rotationForce;
        }
    }
}
