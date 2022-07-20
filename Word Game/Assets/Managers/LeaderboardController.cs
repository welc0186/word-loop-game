using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;

public class LeaderboardController : MonoBehaviour
{
    /*
    public static LeaderboardController Instance;
    public InputField MemberID, PlayerScore;
    public int ID;
    [SerializeField] private int MaxScores;
    private List<HighScore> HighScores;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) => 
        {
            if (!response.success)
            {
                Debug.Log("Error starting LootLocker session");
                return;
            } 
            Debug.Log("Successfully started LootLocker session");
        });
    }

    public void SubmitScore()
    {
        string playerName = PlayerManager.Instance.playerName;
        int playerScore = PlayerManager.Instance.playerScore;
        LootLockerSDKManager.SubmitScore(playerName, playerScore, ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            } else
            {
                Debug.Log("Failed");
            }
        });
    }

    public List<HighScore> GetScores()
    {
        HighScores = new List<HighScore>();
        StartCoroutine(GetScoreRoutine());
        Debug.Log("Returning high scores");
        return HighScores;
    }

    private IEnumerator GetScoreRoutine()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreListMain(ID, MaxScores, 0, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("Error retrieving scores");
                done = true;
                return;
            } 
            
            LootLockerLeaderboardMember[] scores = response.items;
            
            foreach (LootLockerLeaderboardMember score in scores)
            {   
                HighScore newScore = new HighScore(score.rank, score.member_id, score.score);
                HighScores.Add(newScore);
                Debug.Log("Added Score: " + newScore);
            }
            done = true;
        });
        yield return new WaitWhile(() => done == false);
    }
    */

}
