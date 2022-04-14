using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScreenLoader : MonoBehaviour
{
    
    [SerializeField] private GameObject screen;
    [SerializeField] private GameManager.GameState loadFromState;
    [SerializeField] private GameManager.GameState loadToState;

    void Start()
    {
        GameManager.Instance.OnStateChange += HandleGameStateChange;
        Debug.Log("My position: " + transform.position);
    }

    void HandleGameStateChange(object sender, GameManager.OnStateChangeEventArgs e)
    {
        if (e.gameState == loadFromState)
        {
            LoadScreen();
        }
    }

    public virtual void LoadScreen()
    {
        screen.SetActive(true);
        //screen.transform.DOLocalMove(Vector3.zero, 2).OnComplete(() => {
            SetupScreen();
        //});
    }

    public virtual void UnloadScreen()
    {
        //screen.transform.DOLocalMove(new Vector3(0, -1000, 0), 2).OnComplete(() => {
            Debug.Log("Deactivating screen " + screen.name);
            screen.SetActive(false);
            GameManager.Instance.ChangeState(loadToState);
        //});
    }

    public virtual void SetupScreen()
    {

    }

    void OnDisable()
    {
        GameManager.Instance.OnStateChange -= HandleGameStateChange;
    }
}
