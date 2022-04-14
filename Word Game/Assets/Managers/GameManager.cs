using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public GameState gameState;
    private bool firstFrame;

    public class OnStateChangeEventArgs : EventArgs
        {public GameState gameState;}
    public EventHandler<OnStateChangeEventArgs> OnStateChange;
    
    void Awake()
    {
        Instance = this;
        firstFrame = true;
    }

    void Update()
    {
        if (firstFrame)
        {
            ChangeState(GameState.NameEntry);
            firstFrame = false;
        }
    }

    public void ChangeState(GameState newState)
    {
        gameState = newState;
        OnStateChange?.Invoke(this, new OnStateChangeEventArgs {gameState = this.gameState});
    }

    public enum GameState {
        NameEntry,
        MainMenu,
        Leaderboard,
        MainGame
    }

}
