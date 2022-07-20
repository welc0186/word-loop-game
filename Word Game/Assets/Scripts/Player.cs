using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private Table table;
    [SerializeField] private Dictionary dictionary;
    [SerializeField] private CanvasSpawner canvasSpawner;
    [SerializeField] private GameObject wordPrefab;
    [SerializeField] private GameObject letterPrefab;
    [SerializeField] private Score score;

    private Word phaseTwoWord;

    void Awake()
    {
        GameManager.Instance.OnStateChange += HandleGameStateChange;
    }

    void Update()
    {
        HandleLeftRight();
        HandleUpDown();
        HandleSubmitWord();
    }

    void HandleGameStateChange(object sender, GameManager.OnStateChangeEventArgs e)
    {
        switch (e.gameState)
        {
            case GameManager.GameState.RoundStart:
                BuildTable();
                GameManager.Instance.ChangeState(GameManager.GameState.PhaseOne);
                break;
            default:
                break;
        }
    }

    void HandleLeftRight()
    {
        int leftRight = InputManager.Instance.LeftRight;
        if(leftRight != 0)
        {
            SelectAdjSlot(leftRight);
            if(phaseTwoWord != null)
            {
                phaseTwoWord.MoveTo(table.WordSlots[table.selectedWordSlot]);
            }
        }
    }

    void HandleUpDown()
    {
        int upDown = InputManager.Instance.UpDown;
        if(upDown != 0 && GameManager.Instance.gameState == GameManager.GameState.PhaseOne)
        {
            ShiftWord(upDown);
        }
    }

    void HandleSubmitWord()
    {
        if(InputManager.Instance.Submit)
        {
            switch(GameManager.Instance.gameState)
            {
                case GameManager.GameState.PhaseOne:
                    string word = ReadWordAcross();
                    if(dictionary.IsWord(word))
                    {
                        score.AddScore(GetWordAcrossScore());
                        GameManager.Instance.ChangeState(GameManager.GameState.PhaseTwo);
                        phaseTwoWord = SpawnWord(word);
                        phaseTwoWord.MoveTo(table.WordSlots[0]);
                        table.SelectWordSlot(0);
                    }
                    break;
                case GameManager.GameState.PhaseTwo:
                    WordSlot ws = table.WordSlots[table.selectedWordSlot];
                    Destroy(ws.Word.gameObject);
                    phaseTwoWord.MoveAndAssignTo(ws);
                    phaseTwoWord = null;
                    GameManager.Instance.ChangeState(GameManager.GameState.PhaseOne);
                    break;
                default:
                    break;
            }

        }
    }

    public void BuildTable()
    {
        Word[] words = new Word[5];
        for (int i = 0; i < words.Length; i++)
        {
            string s = dictionary.GetRandomCommonWord();
            Word newWord = SpawnWord(s);
            newWord.MoveAndAssignTo(table.WordSlots[i]);
        }
    }

    Word SpawnWord(string s)
    {
        char[] chars = s.ToCharArray(0, 5);
        Letter[] letters = new Letter[chars.Length];
        for(int i = 0; i < chars.Length; i++)
        {
            letters[i] = SpawnLetter(chars[i]);
        }
        Word newWord = canvasSpawner.Spawn(wordPrefab).GetComponent<Word>();
        newWord.Initialize(letters);
        return newWord;
    }

    Letter SpawnLetter(char c)
    {
        Letter newLetter = canvasSpawner.Spawn(letterPrefab).GetComponent<Letter>();
        newLetter.Initialize(c);
        return newLetter;
    }

    public void SelectAdjSlot(int dir)
    {
        table.SelectAdjSlot(dir);
    }

    void ShiftWord(int dir)
    {
        WordSlot[] wordSlots = table.WordSlots;
        int i = table.selectedWordSlot;
        Word w = wordSlots[i].Word;
        w.Shift(dir);
    }

    string ReadWordAcross()
    {
        int x = table.WordSlots.Length;
        char[] chars = new char[x];
        for (int i = 0; i < x; i++)
        {
            chars[i] = table.WordSlots[i].Word.letters[0].Name;
        }
        return new string(chars);
    }

    int GetWordAcrossScore()
    {
        int x = table.WordSlots.Length;
        int s = 0;
        for (int i = 0; i < x; i++)
        {
            s += table.WordSlots[i].Word.letters[0].Points;
        }
        return s;
    }


}
