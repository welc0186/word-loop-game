using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class WordManager : MonoBehaviour
{

    [SerializeField] private LetterGrid letterGrid;
    [SerializeField] private ArrowSelector arrowSelector;
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text promptText;

    [SerializeField] private SFXSO rolloverSFX;
    [SerializeField] private SFXSO correctAnswer;
    [SerializeField] private SFXSO closeOut;

    private Word[] initWords;
    private Word[] words;
    private List<string> foundWords;
    private bool firstFrame;
    private int selectedWord;
    public WordManagerState WordManagerState {get; private set;}
    private float startingTimeSeconds;

    void Awake()
    {
        firstFrame = true;
        selectedWord = 1;
    }

    void Start()
    {
        arrowSelector.SelectUpDownArrows(selectedWord-1);
    }

    void Update()
    {
        if(firstFrame)
        {
            firstFrame = false;
            UpdateState(WordManagerState.Initialize);
        }

        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            ShiftWordUp();
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            ShiftWordDown();
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            SelectWordRight();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SelectWordLeft();
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            ReplaceWord();
        }

    }

    public void UpdateState(WordManagerState newState)
    {
        WordManagerState = newState;
        switch(newState)
        {
            case WordManagerState.Initialize:
                InitializeWords();
                break;
            case WordManagerState.Play:
                StartPlayState();
                break;
            case WordManagerState.Replace:
                StartReplaceState();
                break;
            case WordManagerState.End:
                timer.StopTimer();
                gameOverScreen.SetActive(true);
                break;
            default:
                break;
        }
    }

    void SelectWordUp()
    {
        int prevWord = selectedWord;
        if(selectedWord == 1)
        {
            selectedWord = 5;
        } else
        {
            selectedWord--;
        }
        arrowSelector.SelectArrows(selectedWord);
        if(WordManagerState == WordManagerState.Replace)
        {
            words[selectedWord] = new Word(new string(words[0].letters));
            words[prevWord] = new Word(new string(initWords[prevWord].letters));
            RefreshAllWords();
        }
    }

    void SelectWordDown()
    {
        int prevWord = selectedWord;
        if(selectedWord ==5)
        {
            selectedWord = 1;
        } else
        {
            selectedWord++;
        }
        arrowSelector.SelectArrows(selectedWord);
        if(WordManagerState == WordManagerState.Replace)
        {
            words[selectedWord] = new Word(new string(words[0].letters));
            words[prevWord] = new Word(new string(initWords[prevWord].letters));
            RefreshAllWords();
        }
    }

    void SelectWordRight()
    {
        int prevWord = selectedWord;
        if(selectedWord == 5)
        {
            selectedWord = 1;
        } else
        {
            selectedWord++;
        }
        arrowSelector.SelectUpDownArrows(selectedWord - 1);
        if(WordManagerState == WordManagerState.Replace)
        {
            words[selectedWord] = new Word(new string(words[0].letters));
            words[prevWord] = new Word(new string(initWords[prevWord].letters));
            RefreshAllWords();
            RefreshTransparency();
        }
        rolloverSFX.Play();
    }

    void SelectWordLeft()
    {
        int prevWord = selectedWord;
        if(selectedWord == 1)
        {
            selectedWord = 5;
        } else
        {
            selectedWord--;
        }
        arrowSelector.SelectUpDownArrows(selectedWord - 1);
        if(WordManagerState == WordManagerState.Replace)
        {
            words[selectedWord] = new Word(new string(words[0].letters));
            words[prevWord] = new Word(new string(initWords[prevWord].letters));
            RefreshAllWords();
            RefreshTransparency();
        }
        rolloverSFX.Play();
    }

    void ShiftWordRight()
    {
        if(WordManagerState == WordManagerState.Play)
        {
            words[selectedWord].ShiftRight();
            RefreshWord();
            string midWord = new string(GetMiddleColWord().letters);
            if(WordList.Instance.isWord(midWord) && !foundWords.Contains(midWord))
            {
                UpdateState(WordManagerState.Replace);
            }
        }

    }

    void ShiftWordLeft()
    {
        if(WordManagerState == WordManagerState.Play)
        {
            words[selectedWord].ShiftLeft();
            RefreshWord();
            string midWord = new string(GetMiddleColWord().letters);
            if(WordList.Instance.isWord(midWord) && !foundWords.Contains(midWord))
            {
                UpdateState(WordManagerState.Replace);
            }
        }
    }

    void ShiftWordDown()
    {
        if(WordManagerState == WordManagerState.Play)
        {
            words[selectedWord].ShiftRight();
            RefreshWord();
            //string midWord = new string(GetMiddleColWord().letters);
            string topWord = new string(GetRowWord(0).letters);
            if(WordList.Instance.isWord(topWord) && !foundWords.Contains(topWord))
            {
                UpdateState(WordManagerState.Replace);
            }
        }
        rolloverSFX.Play();

    } 

    void ShiftWordUp()
    {
        if(WordManagerState == WordManagerState.Play)
        {
            words[selectedWord].ShiftLeft();
            RefreshWord();
            //string midWord = new string(GetMiddleColWord().letters);
            string topWord = new string(GetRowWord(0).letters);
            if(WordList.Instance.isWord(topWord) && !foundWords.Contains(topWord))
            {
                UpdateState(WordManagerState.Replace);
            }
        }
        rolloverSFX.Play();

    }       

    void ReplaceWord()
    {
        if(WordManagerState == WordManagerState.Replace)
        {
            words[selectedWord] = words[0];
            words[0] = new Word("     ");
            CopyWords(words, initWords);
            RefreshAllWords();
            closeOut.Play();
            UpdateState(WordManagerState.Play);
        }
    }

    void InitializeWords()
    {
        gameOverScreen.SetActive(false);
        foundWords = new List<string>();
        Word guessWord = new Word(WordList.Instance.GetRandomCommonWord("s"));
        Debug.Log("First guess word: " + new string(guessWord.letters));
        words = new Word[6];
        words[0] = new Word("     ");
        //letterGrid.SetRowLetters(0, words[0]);
        for(int i = 1; i < words.Length; i++)
        {
            words[i] = new Word(WordList.Instance.GetRandomCommonWord(guessWord.letters[i-1].ToString()));
            letterGrid.SetColLetters(i-1, words[i]);
        }
        initWords = new Word[6];
        CopyWords(words, initWords);
        timer.StartTimer();
        PlayerManager.Instance.ResetPlayerScore();
        RefreshTransparency();
        UpdateState(WordManagerState.Play);
    }

    void CopyWords(Word[] from, Word[] to)
    {
        for(int i = 0; i < from.Length; i++)
        {
            to[i] = new Word(new string(from[i].letters));
        }
    }

    void RefreshWord()
    {
        //letterGrid.SetRowLetters(selectedWord, words[selectedWord]);
        letterGrid.SetColLetters(selectedWord - 1, words[selectedWord]);
    }

    void RefreshAllWords()
    {
        for (int i = 0; i < words.Length - 1; i++)
        {
            //letterGrid.SetRowLetters(i, words[i]);
            letterGrid.SetColLetters(i, words[i+1]);
        }
    }

    void RefreshTransparency()
    {
        if(WordManagerState == WordManagerState.Replace)
        {
            letterGrid.SetColTransparent(true);
            letterGrid.SetColTransparent(selectedWord-1, false);
        } else 
        {
            letterGrid.SetColTransparent(false);
        }
    }

    Word GetMiddleColWord()
    {
        string middleCol = new string(new char[] {
            words[1].letters[2],
            words[2].letters[2],
            words[3].letters[2],
            words[4].letters[2],
            words[5].letters[2],
        });

        return new Word(middleCol);
    }

    Word GetMiddleRowWord()
    {
        string middleRow = new string(new char[] {
            words[1].letters[2],
            words[2].letters[2],
            words[3].letters[2],
            words[4].letters[2],
            words[5].letters[2],
        });

        return new Word(middleRow);
    }

    Word GetRowWord(int row)
    {
        string rowString = new string(new char[] {
            words[1].letters[row],
            words[2].letters[row],
            words[3].letters[row],
            words[4].letters[row],
            words[5].letters[row],
        });

        return new Word(rowString);
    }

    void StartPlayState()
    {
        promptText.text = "Form a UNIQUE word across the top row";
        startingTimeSeconds = timer.secondsRemaining;
        RefreshTransparency();
    }

    void StartReplaceState()
    {
        timer.AddSeconds(30);
        PlayerManager.Instance.AddPlayerScore(180 - Mathf.RoundToInt(startingTimeSeconds - timer.secondsRemaining));
        Word topWord = GetRowWord(0);
        foundWords.Add(new string(topWord.letters));
        CopyWords(initWords, words);
        words[0] = topWord;
        selectedWord = 1;
        words[selectedWord] = new Word(new string(words[0].letters));
        arrowSelector.SelectUpDownArrows(selectedWord-1);
        promptText.text = "REPLACE an old word.";
        RefreshAllWords();
        RefreshTransparency();
        correctAnswer.Play();
    }

    public void Reinitialize()
    {
        UpdateState(WordManagerState.Initialize);
    }

    public void EndGame()
    {
        LeaderboardController.Instance.SubmitScore();
        UpdateState(WordManagerState.End);
    }

    void PrintWords()
    {
        for(int i = 0; i < words.Length; i++)
        {
            Debug.Log("Word " + i);
            words[i].PrintWord();
        }
    }

}

public enum WordManagerState {
    Initialize,
    Play,
    Replace,
    End 
}
