using System;
using UnityEngine;

namespace DeepEchoes.Scripts.Enemy
{
    public class BossProjectileForward : MonoBehaviour
    {
        [SerializeField] private float forwardMoveSpeed;
        [SerializeField] private float lifeTime;


        private void Start()
        {
            Destroy(gameObject,lifeTime);
        }

        private void Update()
        {
            transform.position += transform.forward * (forwardMoveSpeed * Time.deltaTime);
        }
    }
}