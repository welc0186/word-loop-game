using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterSlot : MonoBehaviour
{
    //col no longer used - replaced with row
    public int col;
    public int row;
    private TMP_Text text;
    [SerializeField] private float transparentAlpha;

    void Awake()
    {
        text = GetComponentInChildren<TMP_Text>();
    }

    public void SetLetter(char c)
    {
        text.text = c.ToString();
    }

    public void SetTransparent(bool isTransparent)
    {
        Color newColor = text.color;
        if(isTransparent)
        {
            newColor.a = transparentAlpha;
        } else 
        {
            newColor.a = 1;
        }
        text.color = newColor;
    }


}
