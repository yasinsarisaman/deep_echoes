using DeepEchoes.Scripts.Events;
using TMPro;
using UnityEngine;

namespace DeepEchoes.Scripts.Mangers
{
    public class ResourceManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinText;
        private int goldResource; 
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
            goldResource += e.Value;
            coinText.text = goldResource.ToString("000");
        }
    }
}
