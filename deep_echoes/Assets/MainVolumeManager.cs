using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainVolumeManager : MonoBehaviour
{
    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetBackgroundVolume(0.01f); 
        }
    }
}
