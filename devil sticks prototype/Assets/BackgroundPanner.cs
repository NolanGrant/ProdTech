using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPanner : MonoBehaviour
{
    public Material BG_Mat;
    public float BG_PanRate = 1f;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BG_Mat.mainTextureOffset = new Vector2(BG_Mat.mainTextureOffset.x - (BG_PanRate * Time.deltaTime), BG_Mat.mainTextureOffset.y);
    }
}
