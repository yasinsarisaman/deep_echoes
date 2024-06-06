using DeepEchoes.Scripts.Events;
using UnityEngine;

namespace DeepEchoes.Scripts.Environment
{
    public class Resource : Collectable
    {
        [SerializeField] private int _value;
        [SerializeField] private AudioSource _audioSource;
        
        protected override void Collect()
        {
            EventBus<ResourceGainEvent>.Emit(this, new ResourceGainEvent(_value));
            PlayCollectSound();
            base.Collect();
        }
        
        public void PlayCollectSound()
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }
    }
}