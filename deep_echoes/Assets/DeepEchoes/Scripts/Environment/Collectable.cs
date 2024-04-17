using UnityEngine;

namespace DeepEchoes.Scripts.Environment
{
    public class Collectable : MonoBehaviour , IInteractable
    {
        public void Interact()
        {
            Collect();
        }

        protected virtual void Collect()
        {
            Destroy(gameObject);
        }
    }
}