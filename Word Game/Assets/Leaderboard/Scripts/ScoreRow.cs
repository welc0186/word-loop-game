using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreRow : MonoBehaviour
{
    
    [SerializeField] private TMP_Text rankTMP;
    [SerializeField] private TMP_Text nameTMP;
    [SerializeField] private TMP_Text scoreTMP;

    public HighScore RowScore { get; private set; }
    
    public void SetScore(HighScore score)
    {
        RowScore = score;
        rankTMP.text = RowScore.Rank.ToString();
        nameTMP.text = RowScore.Name;
        scoreTMP.text = RowScore.Score.ToString();
    }

}
