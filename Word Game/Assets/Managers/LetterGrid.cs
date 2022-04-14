using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterGrid : MonoBehaviour
{
    [SerializeField] private Letter letterPrefab;
    [SerializeField] private Canvas canvas;
    
    [SerializeField] private Row[] rows;
    [SerializeField] private Col[] cols;

    public void SetRowLetters(int row, Word word)
    {
        for(int i = 0; i < word.letters.Length; i++)
        {
            LetterSlot letterSlot = rows[row].letterSlots[i];
            letterSlot.SetLetter(word.letters[i]);
        }
    }

    public void SetColLetters(int col, Word word)
    {
        for(int i = 0; i < word.letters.Length; i++)
        {
            LetterSlot letterSlot = cols[col].letterSlots[i];
            letterSlot.SetLetter(word.letters[i]);
        }
    }

    public void SetColTransparent(int col, bool isTransparent)
    {
        cols[col].SetColTransparent(isTransparent);
    }

    public void SetColTransparent(bool isTransparent)
    {
        foreach(Col col in cols)
        {
            col.SetColTransparent(isTransparent);
        }
    }

}
