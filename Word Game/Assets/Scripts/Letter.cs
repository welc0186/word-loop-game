using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Letter : MonoBehaviour
{
    
    [HideInInspector] public char Name;
    private TMP_Text text;
    public int Points {get; private set;}

    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    public void Initialize(char c)
    {
        this.Name = c;
        text.text = Name.ToString();
        Points = LetterData.Points[this.Name];
    }

    public void MoveTo(LetterSlot ls)
    {
        this.transform.position = ls.transform.position;
    }


}
