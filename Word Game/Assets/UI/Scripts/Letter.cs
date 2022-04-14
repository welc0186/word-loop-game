using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Letter : MonoBehaviour
{
    
    public char letterName {get; private set;}
    private TMP_Text tmp;

    void Awake()
    {
        tmp = GetComponent<TMP_Text>();
    }
    
    public void SetName(char c)
    {
        letterName = c;
        tmp.text = c.ToString();
    }

}
