using UnityEngine;

public class WordSlot : MonoBehaviour
{

    public LetterSlot[] LetterSlots;
    [HideInInspector] public Word Word;
    [HideInInspector] public bool Selected;

    void Awake()
    {
        Selected = false;
    }

}
