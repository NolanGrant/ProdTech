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

    Coroutine cwDetectFastButtonReleaseCoroutine;
    Coroutine ccwDetectFastButtonReleaseCoroutine;

    // Update is called once per frame
    void Update()
    {
        //rotate clockwise
        if (Input.GetButton("CW") && Input.GetButton("CCW") == false)
        {
            //print("cw");
            if (cwDetectFastButtonReleaseCoroutine == null)
            {
                cwDetectFastButtonReleaseCoroutine = StartCoroutine(DetectFastButtonRelease("CW"));
            }
            else
            {
                StopCoroutine(cwDetectFastButtonReleaseCoroutine);
                cwDetectFastButtonReleaseCoroutine = StartCoroutine(DetectFastButtonRelease("CW"));
            }
            RotatePlayer(-1);
        }
        //rotate counter clockwise
        if (Input.GetButton("CCW") && Input.GetButton("CW") == false)
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
            RotatePlayer(1);
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
            RotatePlayer(0);
        }
    }

    public float maximumTimeToReleaseButtonToRecieveBoost = .5f;
    IEnumerator DetectFastButtonRelease(string button)
    {
        print("coroutine start");
        float timeSincePress = 0;

        while (timeSincePress < maximumTimeToReleaseButtonToRecieveBoost)
        {
            print(timeSincePress);
            timeSincePress += Time.deltaTime;
            if (Input.GetButtonUp(button))
            {
                //apply boost
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
    }

    void RotatePlayer(int rotationDirection)
    {
        //print("rotating");
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
