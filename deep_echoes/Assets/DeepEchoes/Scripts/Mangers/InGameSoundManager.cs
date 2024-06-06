using System;
using DeepEchoes.Scripts.Events;
using UnityEngine;

namespace DeepEchoes.Scripts.Mangers
{
    public class InGameSoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource collectableAudioSource;

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
            collectableAudioSource.PlayOneShot(collectableAudioSource.clip);
        }
    } 
}