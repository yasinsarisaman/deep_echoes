using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using UnityEngine;

public class FirstLevelTutorialManager : MonoBehaviour
{
    [SerializeField] private LeanWindow firstWindow;

    private void Start()
    {
        Invoke(nameof(ShowFirstWindow),4.2f);
    }

    private void ShowFirstWindow()
    {
        firstWindow.On = true;
    }
}
