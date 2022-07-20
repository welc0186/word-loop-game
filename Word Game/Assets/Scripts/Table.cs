using UnityEngine;

public class Table : MonoBehaviour
{
    
    public WordSlot[] WordSlots;
    public int selectedWordSlot { get; private set; }

    void Start()
    {
        SelectWordSlot(0);
    }

    public void SelectWordSlot(int i)
    {
        if(i >= 0 && i < WordSlots.Length)
        {
            WordSlots[selectedWordSlot].Selected = false;
            WordSlots[i].Selected = true;
            selectedWordSlot = i;
        }
    }

    public void SelectAdjSlot(int dir)
    {
        if(dir >= 0)
        {
            SelectWordSlot(selectedWordSlot + 1);
        } else
        {
            SelectWordSlot(selectedWordSlot - 1);
        }
    }

}
