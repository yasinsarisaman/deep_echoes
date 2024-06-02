using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainVolumeManager : MonoBehaviour
{
    [SerializeField] private float volume;
    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetBackgroundVolume(volume); 
        }
    }
}
