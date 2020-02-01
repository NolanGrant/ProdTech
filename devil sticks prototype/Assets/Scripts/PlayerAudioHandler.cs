using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioHandler : MonoBehaviour
{
    AudioSource playerAudio;
    AudioClip impact;
    AudioClip miss;

    GameObject rotatingObject;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        impact = playerAudio.clip;
        miss = playerAudio.clip;
    }

    // Update is called once per frame
    void Update()
    {
        rotatingObject = GameObject.Find("Rotating Object");
    }

    public void PlaySound()
    {
        playerAudio.pitch = Random.Range(0.5f, 2f);
        playerAudio.PlayOneShot(impact);
    }

    public void PlayMissSound()
    {
        if (rotatingObject.transform.position.x <= -10)
        {
            playerAudio.PlayOneShot(miss);
        }
    }

}
