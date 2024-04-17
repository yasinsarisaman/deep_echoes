using DeepEchoes.Scripts.Events;
using TMPro;
using UnityEngine;

namespace DeepEchoes.Scripts.Mangers
{
    public class HealthManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI remainingHealthText;
        private int _remainingHealth = 100; 
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
            _remainingHealth -= e.Value;
            remainingHealthText.text = _remainingHealth.ToString("000");
        }
    }
}