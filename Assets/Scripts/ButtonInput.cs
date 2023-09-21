using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    [SerializeField] SceneSwitcher sceneSwitcher;
    public void StartButton()
    {
        sceneSwitcher.SwitchScene();
    }
    public void ExitButton()
    {
        Environment.Exit(0);
    }
}
