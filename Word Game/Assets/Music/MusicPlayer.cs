using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private float musicFrequencySeconds;
    [SerializeField] private float initialMusicTimeSeconds;
    [SerializeField] private AudioSource audioSource;

    private float secondsRemaining;

    void Awake()
    {
        secondsRemaining = initialMusicTimeSeconds;
    }

    void Update()
    {
        if (secondsRemaining > 0)
        {
            secondsRemaining = secondsRemaining - Time.deltaTime;
            if(secondsRemaining <= 0)
            {
                if(!audioSource.isPlaying)
                {
                audioSource.Play();
                }
                secondsRemaining = musicFrequencySeconds;
            }
        }
    }

}
