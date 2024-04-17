using DeepEchoes.Scripts.Events;
using UnityEngine;

namespace DeepEchoes.Scripts.Environment
{
    public class Trap : Damagable
    {
        [SerializeField] private int _value;
        
        protected override void ApplyDamage()
        {
            EventBus<ApplyDamageEvent>.Emit(this, new ApplyDamageEvent(_value));
            base.ApplyDamage();
        }
        
    }
}