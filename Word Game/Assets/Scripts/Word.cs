using UnityEngine;

public class Word : MonoBehaviour
{
    
    [SerializeField] private Letter letterPrefab;
    public Letter[] letters { get; private set; }
    private Letter[] originalWord;
    private WordSlot wordSlot;
    
    void Awake()
    {
        GameManager.Instance.OnStateChange += HandleGameStateChange;
    }
    
    public void Initialize(Letter[] l)
    {
        letters = l;
        originalWord = new Letter[l.Length];
        for(int i = 0; i < l.Length; i++)
        {
            originalWord[i] = l[i];
        }
    }

    void HandleGameStateChange(object sender, GameManager.OnStateChangeEventArgs e)
    {
        switch (e.gameState)
        {
            case GameManager.GameState.PhaseTwo:
                for(int i = 0; i < letters.Length; i ++)
                {
                    letters[i] = originalWord[i];
                }
                MoveTo(wordSlot);
                break;
            default:
                break;
        }
    }

    public void MoveTo(WordSlot ws)
    {
        wordSlot = ws;
        for(int i = 0; i < letters.Length; i++)
        {
            letters[i].MoveTo(wordSlot.LetterSlots[i]);
        }
    }

    public void AssignTo(WordSlot ws)
    {
        ws.Word = this;
    }

    public void MoveAndAssignTo(WordSlot ws)
    {
        MoveTo(ws);
        AssignTo(ws);
    }

    public void Shift(int dir)
    {
        int x = letters.Length;
        if(dir < 0)
        {
            Letter lastLetter = letters[x-1];
            for(int i = x - 1; i > 0; i--)
            {
                letters[i] = letters[i-1];
            }
            letters[0] = lastLetter;
        }
        if(dir > 0)
        {
            Letter firstLetter = letters[0];
            for(int i = 0; i < x - 1; i++)
            {
                letters[i] = letters[i+1];
            }
            letters[x - 1] = firstLetter;
        }
        MoveTo(wordSlot);
    }

    void OnDestroy()
    {
        GameManager.Instance.OnStateChange -= HandleGameStateChange;
        foreach(Letter l in letters)
        {
            if (l != null)
            {
                Destroy(l.gameObject);
            }
        }
    }

    void DebugPrintLetters(Letter[] l)
    {
        for(int i = 0; i < l.Length; i++)
        {
            Debug.Log(i + ": " + l[i].Name);
        }
    }


}
