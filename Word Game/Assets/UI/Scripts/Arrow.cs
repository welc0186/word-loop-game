using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    
    private Image image;

    void Awake()
    {
        image = GetComponentInChildren<Image>();
        Deactivate();
    }

    public void Activate()
    {
        Color color = image.color;
        color.a = 1;
        image.color = color;

    }

    public void Deactivate()
    {
        Color color = image.color;
        color.a = 0;
        image.color = color;
    }

}
