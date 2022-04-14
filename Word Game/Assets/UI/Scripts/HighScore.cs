using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HighScore
{
    
    public HighScore(int rank, string name, int score)
    {
        Rank = rank;
        Name = name;
        Score = score;
    }

    public int Rank { get; }
    public string Name { get; }
    public int Score { get; }

    public override string ToString() => $"Rank: {Rank}, Name: {Name}, Score: {Score}";

}
