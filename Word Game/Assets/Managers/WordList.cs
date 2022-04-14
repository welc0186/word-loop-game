using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WordList : MonoBehaviour
{
    
    public static WordList Instance;

    [SerializeField] private TextAsset dictionaryText;
    [SerializeField] private TextAsset wordListText;

    private List<string> dictionaryList;
    private List<string> wordList;
    
    void Awake()
    {
        Instance = this;

        dictionaryList = new List<string>();
        wordList = new List<string>();
        AddTextFileWordsToList(dictionaryText, dictionaryList);
        AddTextFileWordsToList(wordListText, wordList);

    }

    void AddTextFileWordsToList(TextAsset file, List<string> list)
    {
        string text = file.text;
        char[] separator = { ',' };
        string[] singleWords = text.Split(separator);
        foreach (string newWord in singleWords)
        {
            list.Add(newWord);
        }
    }

    public string GetRandomCommonWord()
    {
        int rand = Random.Range(0, wordList.Count);
        return wordList[rand];
    }

    public string GetRandomCommonWord(string contains)
    {
        int rand = Random.Range(0, wordList.Count);
        while(!wordList[rand].Contains(contains))
        {
            rand = Random.Range(0, wordList.Count);
        }
        return wordList[rand];
    }

    public bool isWord(string word)
    {
        if (wordList.Contains(word) || dictionaryList.Contains(word))
        {
            return true;
        }
        return false;
    }

}
