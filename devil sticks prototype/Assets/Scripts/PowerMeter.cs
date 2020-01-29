using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerMeter : MonoBehaviour
{
    public Image meter;
    float meterGain = 0.5f;
    float meterDrain = 6;
    float maxMeter = 100;
    public float currentMeter;
    float newMeter;

    // Start is called before the first frame update
    void Start()
    {
        currentMeter = maxMeter / 2;
    }

    // Update is called once per frame
    void Update()
    {
        MeterControl();
    }

    void MeterControl()
    {
        meter.fillAmount = currentMeter / maxMeter;
        if (currentMeter > 66)
        {
            meter.color = Color.green;
        }
        else if(currentMeter > 33 && currentMeter < 66)
        {
            meter.color = Color.yellow;
        }
        else if (currentMeter < 33)
        {
            meter.color = Color.red;
        }
    }

    public void GainMeter()
    {
        if (currentMeter < maxMeter)
        {
            currentMeter += meterGain;
        }

        if (currentMeter >= maxMeter)
        {
            currentMeter = maxMeter;
        }
    }

    public void DrainMeter()
    {
        if (currentMeter > 0)
        {
            currentMeter -= meterDrain;
        }

        if (currentMeter <= 0)
        {
            currentMeter = 0;
        }
    }
}
