using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioHandler : MonoBehaviour
{
    AudioSource playerAudio;
    AudioClip impact;
    AudioClip missSound;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        impact = playerAudio.clip;
        missSound = playerAudio.clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        playerAudio.pitch = Random.Range(0.5f, 2f);
        playerAudio.PlayOneShot(impact);
    }

    public void PlayMissSound()
    {
        playerAudio.pitch = Random.Range(0.5f, 2f);
        playerAudio.PlayOneShot(missSound);
    }
}
