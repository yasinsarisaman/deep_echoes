using System;
using DeepEchoes.Scripts.Events;
using TMPro;
using UnityEngine;

namespace DeepEchoes.Scripts.Mangers
{
    public class ResourceManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinText;

        private int goldResource
        {
            get => PlayerPrefs.GetInt(goldPrefName, 0);
            set
            {
                PlayerPrefs.SetInt(goldPrefName,value);
                coinText.text = "Gold: " + value;
            }
        }
        private const string goldPrefName = "goldPref";

        private void Start()
        {
            goldResource = goldResource;
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
            goldResource += e.Value;
        }
    }
}
