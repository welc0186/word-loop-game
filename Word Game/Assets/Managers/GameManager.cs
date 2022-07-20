using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    [HideInInspector] public GameState gameState;

    public class OnStateChangeEventArgs : EventArgs
        {public GameState gameState;}
    public EventHandler<OnStateChangeEventArgs> OnStateChange;
    
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Canvas.ForceUpdateCanvases();
        ChangeState(0);
    }

    public void ChangeState(GameState newState)
    {
        gameState = newState;
        OnStateChange?.Invoke(this, new OnStateChangeEventArgs {gameState = this.gameState});
    }

    //First enum is initialized at beginning of game
    public enum GameState {
        RoundStart,
        PhaseOne,
        PhaseTwo
    }

}
