using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    [SerializeField] GameObject cam;
    [SerializeField] Animator animator;
    [SerializeField] SceneSwitcher sceneSwitcher;
    bool b;
    public void StartButton()
    {
        sceneSwitcher.SwitchScene();
    }
    public void HowToPlay()
    {
        animator.Play("Position_Animation");
        b= true;
    }
    public void ExitButton()
    {
        Application.Quit(0);
    }
    public void BackButton()
    {
        if (b)
        {
            animator.SetTrigger("Back");
            b = false;
        }
    }
}
