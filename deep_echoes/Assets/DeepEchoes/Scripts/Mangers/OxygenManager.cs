using System.Collections;
using System.Collections.Generic;
using DeepEchoes.Scripts.Events;
using UnityEngine;
using UnityEngine.UI;

public class OxygenManager : MonoBehaviour
{
    [SerializeField] private float _oxygenAmount = 1.0f;
    [SerializeField] private Slider _oxygenSlider;
    [SerializeField] private int _oxygenDecreaseFactor = 3; 
    
    void Update()
    {
        _oxygenAmount -= Time.deltaTime / _oxygenDecreaseFactor;
        _oxygenSlider.value = _oxygenAmount;
        if (_oxygenAmount <= 0)
        {
            EventBus<LevelCompletedEvent>.Emit(this, new LevelCompletedEvent(CompletionStates.CompletionState_LOSE_BY_OXYGEN));
        }
    }
}
