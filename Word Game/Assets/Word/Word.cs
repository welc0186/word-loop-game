using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word
{
    
    public char[] letters {get; private set;}

    public Word(string word)
    {
        letters = word.ToCharArray();
    }

    public char[] ShiftLeft()
    {
        char firstChar = letters[0];
        for (int i = 0; i < letters.Length - 1; i++)
        {
            letters[i] = letters[i+1];
        }
        letters[letters.Length-1] = firstChar;
        return letters;
    }

    public char[] ShiftRight()
    {
        char lastChar = letters[letters.Length-1];
        for (int i = letters.Length-1; i > 0; i--)
        {
            letters[i] = letters[i-1];
        }
        letters[0] = lastChar;
        return letters;
    }

    public void PrintWord()
    {
        string word = new string(letters);
        Debug.Log("Printing Word: " + word);
    }

}
