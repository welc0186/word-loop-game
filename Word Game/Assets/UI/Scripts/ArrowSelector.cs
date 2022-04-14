using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSelector : MonoBehaviour
{
    
    [SerializeField] private Arrow[] leftArrows;
    [SerializeField] private Arrow[] rightArrows;
    [SerializeField] private Arrow[] upArrows;
    [SerializeField] private Arrow[] downArrows;
    
    public void SelectArrows(int row)
    {
        for (int i = 0; i < leftArrows.Length; i++)
        {
            if (i == row)
            {
                leftArrows[i].Activate();
                rightArrows[i].Activate();
            } else
            {
                leftArrows[i].Deactivate();
                rightArrows[i].Deactivate();
            }
        }
    }

    public void SelectUpDownArrows(int col)
    {
        for (int i = 0; i < upArrows.Length; i++)
        {
            if (i == col)
            {
                upArrows[i].Activate();
                downArrows[i].Activate();
            } else
            {
                upArrows[i].Deactivate();
                downArrows[i].Deactivate();
            }
        }
    }

}
