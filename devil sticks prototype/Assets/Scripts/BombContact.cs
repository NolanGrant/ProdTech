using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombContact : MonoBehaviour
{
    public GameObject circle;
    public GameObject triangle;
    public SpriteRenderer cSR;
    public SpriteRenderer tSR;
    CircleCollider2D circleCollider;
    PolygonCollider2D triangleCollider;

    bool triangleDisabled = false;
    float tDisableTime = 4;
    float currentTDisableTime;
    float currentTFlashTime;
    float tFlashTime = 0.2f;
    bool tFlash = false;

    bool circleDisabled = false;
    float cDisableTime = 4;
    float currentCDisableTime;
    float currentCFlashTime;
    float cFlashTime = 0.2f;
    bool cFlash = false;

    public AudioSource bombAudio;
    AudioClip bombExplosion;

    // Start is called before the first frame update
    void Start()
    {
        bombExplosion = bombAudio.clip;
       circleCollider = circle.GetComponentInChildren<CircleCollider2D>();
       triangleCollider = triangle.GetComponentInChildren<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FlashShapes();
        ResetShapes();
    }

    public void DisableCircle()
    {
     if (!circleDisabled)
        {
            bombAudio.PlayOneShot(bombExplosion);
            //set circle disabled
            currentCDisableTime = Time.time;
            circleCollider.enabled = false;
            circleDisabled = true;
        }
    }

    public void DisableTriangle()
    {
        if (!triangleDisabled)
        {
            bombAudio.PlayOneShot(bombExplosion);
            //set triangle disabled
            currentTDisableTime = Time.time;
            triangleCollider.enabled = false;
            triangleDisabled = true;
        }
    }

    void FlashShapes()
    {
        //flash triangle to show that object is disbaled
        if (triangleDisabled)
        {
            if (!tFlash && Time.time > currentTFlashTime + tFlashTime)
            {
                tSR.enabled = false;
                currentTFlashTime = Time.time;
                tFlash = true;
            }

            if (tFlash && Time.time > currentTFlashTime + tFlashTime)
            {
                tSR.enabled = true;
                currentTFlashTime = Time.time;
                tFlash = false;
            }
        }
        else
        {
            //set sprite permanently active
            tSR.enabled = true;
            tFlash = false;
        }

        //flash circle to show that object is disabled
        if (circleDisabled)
        {
            if (!cFlash && Time.time > currentCFlashTime + cFlashTime)
            {
                cSR.enabled = false;
                currentCFlashTime = Time.time;
                cFlash = true;
            }

            if (cFlash && Time.time > currentCFlashTime + cFlashTime)
            {
                cSR.enabled = true;
                currentCFlashTime = Time.time;
                cFlash = false;
            }
        }
        else
        {
            //set sprite permanently active
            cSR.enabled = true;
            cFlash = false;
        }

    }

    void ResetShapes()
    {
        //when disabled time is up, enable collider
        if (triangleDisabled && Time.time > currentTDisableTime + tDisableTime)
        {
            triangleCollider.enabled = true;
            triangleDisabled = false;
        }
        //when disabled time is up, enable collider
        if (circleDisabled && Time.time > currentCDisableTime + cDisableTime)
        {
            circleCollider.enabled = true;
            circleDisabled = false;
        }
    }
}
