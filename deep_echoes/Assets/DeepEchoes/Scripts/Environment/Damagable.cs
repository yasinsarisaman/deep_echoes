using UnityEngine;

namespace DeepEchoes.Scripts.Environment
{
    public class Damagable : MonoBehaviour , IInteractable
    {
        public void Interact()
        {
            ApplyDamage();
        }

        protected virtual void ApplyDamage()
        {
            Destroy(gameObject);
        }
    }
}