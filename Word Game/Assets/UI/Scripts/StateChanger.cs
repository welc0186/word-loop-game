using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChanger : MonoBehaviour
{
    
    [SerializeField] private GameManager.GameState gameState;
    
    public void ChangeState()
    {
        GameManager.Instance.ChangeState(gameState);
    }
}
