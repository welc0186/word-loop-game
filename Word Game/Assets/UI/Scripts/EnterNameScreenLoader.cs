using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EnterNameScreenLoader : ScreenLoader
{

    [SerializeField] private InputField inputField;

    public override void SetupScreen()
    {
        base.SetupScreen();
        inputField.Select();
    }


}
