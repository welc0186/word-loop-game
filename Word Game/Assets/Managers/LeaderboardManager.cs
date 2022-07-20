using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class LeaderboardManager : MonoBehaviour
{
    /*
    [SerializeField] private ScoreRow[] scoreRows;
    
    void OnEnable()
    {
        StartCoroutine(GetScoreRoutine());
    }

    private IEnumerator GetScoreRoutine()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreListMain(LeaderboardController.Instance.ID, scoreRows.Length, 0, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("Error retrieving scores");
                done = true;
                return;
            } 
            
            LootLockerLeaderboardMember[] scores = response.items;
            for(int i = 0; i < scoreRows.Length; i++)
            {
                if (i < scores.Length)
                {
                    HighScore newScore = new HighScore(scores[i].rank, scores[i].member_id, scores[i].score);
                    scoreRows[i].SetScore(newScore);
                    Debug.Log("Set score: " + newScore.ToString());
                } else
                {
                    scoreRows[i].SetScore(new HighScore(i + 1, "     ", 0));
                }
            }
            done = true;
        });
        yield return new WaitWhile(() => done == false);
    }
    */

}
