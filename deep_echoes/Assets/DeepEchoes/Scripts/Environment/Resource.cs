using DeepEchoes.Scripts.Events;
using UnityEngine;

namespace DeepEchoes.Scripts.Environment
{
    public class Resource : Collectable
    {
        [SerializeField] private int _value;
        
        protected override void Collect()
        {
            EventBus<ResourceGainEvent>.Emit(this, new ResourceGainEvent(_value));
            base.Collect();
        }
    }
}