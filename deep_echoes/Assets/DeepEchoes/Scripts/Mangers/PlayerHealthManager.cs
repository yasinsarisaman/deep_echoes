using System;
using DeepEchoes.Scripts.Events;
using TMPro;
using UnityEngine;

namespace DeepEchoes.Scripts.Mangers
{
    public class PlayerHealthManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI remainingHealthText;
        [SerializeField] private int startHealth = 100;
        
        private int _currentHealth;

        private void Start()
        {
            _currentHealth = startHealth;
            remainingHealthText.text = "Health: " + _currentHealth;
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
            remainingHealthText.text = "Health: " + _currentHealth;
        }
    }
}