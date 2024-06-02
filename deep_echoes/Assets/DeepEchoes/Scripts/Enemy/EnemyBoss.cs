using System;
using System.Collections;
using System.Collections.Generic;
using DeepEchoes.Scripts.Events;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace DeepEchoes.Scripts.Enemy
{
    public class EnemyBoss : MonoBehaviour
    {
        [SerializeField] private float waitTimeBeforeShoot;
        [SerializeField] private int bossTouchDamage = 5;
        
        
       
        [SerializeField] private Transform shootTransform;
        [SerializeField] private float waitTimeBetweenShoots;
        [SerializeField] private int shootAmount;
         
        
        [SerializeField] private float rotateSpeed;
        
        [SerializeField] private BossProjectileForward bossProjectileForwardPrefab;
        [SerializeField] private BossProjectileHoming bossProjectileHoming;
        [SerializeField] private Animator bossAnimator;

        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = PlayerController.Instance.transform;
            StartCoroutine(BossAI());
        }

        private void Update()
        {
            var lookVector =(_playerTransform.position-transform.position).normalized;
            lookVector.y = 0;
            
            transform.rotation = Quaternion.Slerp( transform.rotation ,Quaternion.LookRotation(lookVector),rotateSpeed*Time.deltaTime);
        }

        private IEnumerator BossAI()
        {
            while (true)
            {
                yield return new WaitForSeconds(waitTimeBeforeShoot);
                for (var i = 0; i < shootAmount; i++)
                {
                    var projectile = Instantiate(bossProjectileForwardPrefab, shootTransform.position, quaternion.identity);
                    projectile.transform.forward = (_playerTransform.position + Vector3.up*2f - projectile.transform.position).normalized;
                    bossAnimator.SetTrigger("Bite");
                    yield return new WaitForSeconds(waitTimeBetweenShoots);
                    
                }
                yield return new WaitForSeconds(waitTimeBeforeShoot);
                Instantiate(bossProjectileHoming, shootTransform.position, quaternion.identity);
                bossAnimator.SetTrigger("Bite");
                yield return new WaitForSeconds(waitTimeBetweenShoots);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out PlayerController playerController))
            {
                EventBus<ApplyDamageEvent>.Emit(this, new ApplyDamageEvent(bossTouchDamage));
                AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip,Camera.main.transform.position);
                 playerController.PushBack(transform.position);
            }
        }
    }
}