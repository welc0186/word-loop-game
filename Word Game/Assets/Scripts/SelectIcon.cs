using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SelectIcon : MonoBehaviour
{
    
    [SerializeField] private Table table;
    private int selectedWordSlot = 0;

    void Start()
    {
        MoveX(table.WordSlots[0].transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        if(table.selectedWordSlot != selectedWordSlot)
        {
            selectedWordSlot = table.selectedWordSlot;
            MoveX(table.WordSlots[selectedWordSlot].transform.position.x);
        }
    }

    void MoveX(float x)
    {
        Vector3 pos = GetComponent<RectTransform>().position;
        GetComponent<RectTransform>().position = new Vector3(x, pos.y, pos.z);
    }

}
