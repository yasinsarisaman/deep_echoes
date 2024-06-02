using DeepEchoes.Scripts.Events;
using UnityEngine;

namespace DeepEchoes.Scripts.Environment
{
    public class Trap : Damagable
    {
        [SerializeField] private int _value;
        [SerializeField] private AudioSource _audioSource;
        
        protected override void ApplyDamage()
        {
            EventBus<ApplyDamageEvent>.Emit(this, new ApplyDamageEvent(_value));
            PlayColisionSound();
            base.ApplyDamage();
        }
        
        public void PlayColisionSound()
        {
            AudioSource.PlayClipAtPoint(_audioSource.clip,Camera.main.transform.position);
            
            // if (!_audioSource.isPlaying)
            // {
            //     _audioSource.Play();
            // }
        }
    }
}