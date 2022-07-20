using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPrinter : MonoBehaviour
{

    private int frame = 0;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(frame + ": " + this.transform.position);
        frame++;   
    }
}
