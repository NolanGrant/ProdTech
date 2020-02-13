using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public Image WinImage;
    public Image Failimage;
    PowerMeter pmScript;

    bool hasWon = false;
    bool hasFailed = false;

    // Start is called before the first frame update
    void Start()
    {
        WinImage.enabled = false;
        Failimage.enabled = false;
        pmScript = GetComponent<PowerMeter>();
        hasFailed = false;
        hasWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetState();
    }

    void SetState()
    {
        if (pmScript.currentMeter >= pmScript.maxMeter && !hasWon)
        {
            hasWon = true;
            WinImage.enabled = true;
            Time.timeScale = 0;
        }

        if (pmScript.currentMeter <= 0 && !hasFailed)
        {
            hasFailed = true;
            Failimage.enabled = true;
            Time.timeScale = 0;
        }
    }
}
