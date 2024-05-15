using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using UnityEngine;

public class FirstLevelTutorialManager : MonoBehaviour
{
    [SerializeField] private LeanWindow firstWindow;
    private const string tutorialPrefString = "isTutorialCompleted";
   

    private void Start()
    {
        if (PlayerPrefs.GetInt(tutorialPrefString, 0) == 0)
        {
            PlayerPrefs.SetInt(tutorialPrefString,1);
            Invoke(nameof(ShowFirstWindow),4.2f);
        }
    }

    private void ShowFirstWindow()
    {
        firstWindow.On = true;
    }
}
