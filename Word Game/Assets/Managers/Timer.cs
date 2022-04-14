using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Timer : MonoBehaviour
{
    
    [SerializeField] private float initialTimeSeconds;
    [SerializeField] private UnityEvent OnTimerExpire;
    [SerializeField] private float maximumTimeSeconds;

    [SerializeField] private SFXSO timeoutSFX;

    public float secondsRemaining {get; private set;}

    void Update()
    {
        if (secondsRemaining > 0)
        {
            secondsRemaining = secondsRemaining - Time.deltaTime;
            if(secondsRemaining <= 0)
            {
                timeoutSFX.Play();
                OnTimerExpire.Invoke();
            }
        }
    }

    public void StartTimer()
    {
        secondsRemaining = initialTimeSeconds;
    }

    public void StopTimer()
    {
        secondsRemaining = -1;
    }

    public void AddSeconds(float seconds)
    {
        if (secondsRemaining > maximumTimeSeconds)
        {
            return;
        }
        secondsRemaining = Mathf.Min(secondsRemaining + seconds, maximumTimeSeconds);
    }

}
