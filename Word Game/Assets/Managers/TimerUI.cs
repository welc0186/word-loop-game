using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerUI : MonoBehaviour
{
    
    [SerializeField] private Timer timer;

    private TMP_Text tmp_Text;
    
    // Start is called before the first frame update
    void Awake()
    {
        tmp_Text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan time = TimeSpan.FromSeconds(timer.secondsRemaining);
        tmp_Text.text = time.ToString(@"m\:ss");
    }
}
