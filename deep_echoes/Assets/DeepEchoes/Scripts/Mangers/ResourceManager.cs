using System;
using DeepEchoes.Scripts.Events;
using TMPro;
using UnityEngine;

namespace DeepEchoes.Scripts.Mangers
{
    public class ResourceManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private int _requiredWrenchesCount;
        private int _currentWrenchesCount = 0;
        

        private void Start()
        {
            coinText.text = _currentWrenchesCount + " / " + _requiredWrenchesCount;
        }

        private void OnEnable()
        {
            EventBus<ResourceGainEvent>.AddListener(OnResourceGainEvent);
        }

        private void OnDisable()
        {
            EventBus<ResourceGainEvent>.RemoveListener(OnResourceGainEvent);
        }

        private void OnResourceGainEvent(object sender, ResourceGainEvent e)
        {
            _currentWrenchesCount++;
            coinText.text = _currentWrenchesCount + " / " + _requiredWrenchesCount;
            if (_requiredWrenchesCount <= _currentWrenchesCount)
            {
                EventBus<LevelCompletedEvent>.Emit(this, new LevelCompletedEvent(CompletionStates.CompletionState_WIN));
            }
        }
    }
}
