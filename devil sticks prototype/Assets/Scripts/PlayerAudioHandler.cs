using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioHandler : MonoBehaviour
{
    AudioSource playerAudio;
    AudioClip impact;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        impact = playerAudio.clip;
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
}
