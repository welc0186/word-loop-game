using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    private TMP_Text text;
    private int score;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
        score = 0;
        text.text = score.ToString();
    }

    public int AddScore(int i)
    {
        score += i;
        text.text = score.ToString();
        return score;
    }



}
