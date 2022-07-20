using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictionary : MonoBehaviour
{
    
    [SerializeField] private TextAsset commonWordFile;
    [SerializeField] private TextAsset uncommonWordFile;

    private List<string> commonWords;
    private List<string> uncommonWords;

    void Awake()
    {
        commonWords = FileToWords(commonWordFile);
        uncommonWords = FileToWords(uncommonWordFile);
    }
    
    public string GetRandomCommonWord()
    {
        int r = Random.Range(0, commonWords.Count);
        return commonWords[r];
    }

    List<string> FileToWords(TextAsset file)
    {
        string text = file.text;
        string[] s = text.Split(',');
        List<string> list = new List<string>();
        foreach(string word in s)
        {
            list.Add(word);
        }
        return list;
    }

    public bool IsWord(string word)
    {
        if(commonWords.Contains(word) || uncommonWords.Contains(word))
        {
            return true;
        }
        return false;
    }

}
