using System;
using DeepEchoes.Scripts.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DeepEchoes.Scripts.Mangers
{
    public class PlayerHealthManager : MonoBehaviour
    {
        //[SerializeField] private TextMeshProUGUI remainingHealthText;
        [SerializeField] private Slider _healthBar;
        [SerializeField] private int startHealth = 100;
        
        private int _currentHealth;

        private void Start()
        {
            _currentHealth = startHealth;
            _healthBar.value = (float)_currentHealth/100;
        }

        private void OnEnable()
        {
            EventBus<ApplyDamageEvent>.AddListener(OnApplyDamageEvent);
        }

        private void OnDisable()
        {
            EventBus<ApplyDamageEvent>.RemoveListener(OnApplyDamageEvent);
        }

        private void OnApplyDamageEvent(object sender, ApplyDamageEvent e)
        {

            _currentHealth -= e.Value;
            _healthBar.value = (float)_currentHealth/100;

            if (_currentHealth <= 0)
            {
                EventBus<LevelCompletedEvent>.Emit(this, new LevelCompletedEvent(CompletionStates.CompletionState_LOSE_BY_HEALTH));
            }
        }
    }
}