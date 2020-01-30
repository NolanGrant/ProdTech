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
    bool circleDisabled = false;
    float cDisableTime = 4;
    float currentCDisableTime;

    // Start is called before the first frame update
    void Start()
    {
       circleCollider = circle.GetComponent<CircleCollider2D>();
       triangleCollider = triangle.GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FlashShapes();
    }

    public void DisableCircle()
    {
     if (circleDisabled)
        {
            currentCDisableTime = Time.time;
            circleCollider.enabled = false;
            circleDisabled = false;
        }
    }

    public void DisableTriangle()
    {
        if (triangleDisabled)
        {
            currentTDisableTime = Time.time;
            triangleCollider.enabled = false;
            triangleDisabled = false;
        }
    }

    void FlashShapes()
    {
        if (triangleDisabled)
        {

        }
    }

    void ResetShapes()
    {
        if (triangleDisabled && Time.time > currentTDisableTime + tDisableTime)
        {

        }
    }
}
