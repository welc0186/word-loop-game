using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public string playerName {get; private set;}
    public int playerScore {get; private set;}

    void Awake()
    {
        ResetPlayerScore();
        Instance = this;
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public void AddPlayerScore(int score)
    {
        playerScore += score;
    }

    public void ResetPlayerScore()
    {
        playerScore = 0;
    }

}
