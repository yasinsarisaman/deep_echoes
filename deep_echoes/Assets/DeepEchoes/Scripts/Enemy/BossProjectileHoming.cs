using UnityEngine;

namespace DeepEchoes.Scripts.Enemy
{
    public class BossProjectileHoming : MonoBehaviour
    {
        
        [SerializeField] private float forwardMoveSpeed;
        [SerializeField] private float lifeTime;
        private Transform _playerTransform;

        private void Start()
        {
            Destroy(gameObject,lifeTime);
            _playerTransform = PlayerController.Instance.transform;
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, _playerTransform.position + Vector3.up*2,
                forwardMoveSpeed * Time.deltaTime);
        }
    }
}