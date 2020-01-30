using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score;
    public Text scoreText;

    public bool increaseSpeed = false;
    float speedUpTime = 8;
    float currentTime;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        TrackSpeedUp();
    }

    public void Addpoint()
    {
        score += 1;
    }

    public void SpeedUp()
    {
        if (!increaseSpeed)
        {
            increaseSpeed = true;
            currentTime = Time.time;
        }
    }

    void TrackSpeedUp()
    {
        if (increaseSpeed && Time.time > currentTime + speedUpTime)
        {
            increaseSpeed = false;
        }
    }
}
