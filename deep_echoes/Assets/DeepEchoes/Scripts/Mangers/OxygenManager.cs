using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenManager : MonoBehaviour
{
    [SerializeField] private Slider _oxygenSlider;

    [SerializeField] private int _oxygenDecreaseFactor = 3; 
    
    void Update()
    {
        _oxygenSlider.value -= Time.deltaTime / _oxygenDecreaseFactor;
    }
}
