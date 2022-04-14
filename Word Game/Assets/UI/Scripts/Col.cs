using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col : MonoBehaviour
{
    
    [SerializeField] public int col;
    [SerializeField] public LetterSlot[] letterSlots;

    public void SetColTransparent(bool isTransparent)
    {
        foreach(LetterSlot letterSlot in letterSlots)
        {
            letterSlot.SetTransparent(isTransparent);
        }
    }

}
