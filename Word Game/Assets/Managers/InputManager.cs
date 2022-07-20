using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    public static InputManager Instance;
    [HideInInspector] public int LeftRight = 0;
    [HideInInspector] public int UpDown = 0;
    [HideInInspector] public bool Submit = false;

    
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleLeftRight(); 
        HandleUpDown();
        HandleSubmit();
    }

    void HandleLeftRight()
    {
        LeftRight = 0;
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            LeftRight++;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftRight--;
        }
    }

    void HandleUpDown()
    {
        UpDown = 0;
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            UpDown++;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            UpDown--;
        }
    }

    void HandleSubmit()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Submit = true;
        } else 
        {
            Submit = false;
        }
    }

}
