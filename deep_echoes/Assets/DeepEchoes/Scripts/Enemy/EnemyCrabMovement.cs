using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyCrabMovement : MonoBehaviour
{
    [SerializeField] private float moveTime;
    [SerializeField] private float moveAmount;

    private bool _isRightMove;


    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0, 0.5f));
            var randomDir = Random.Range(0, 4);
            transform.DORotate( Vector3.up * (90f*randomDir), 0.3f);
            yield return new WaitForSeconds(0.3f);
            transform.DOMove(transform.position + transform.forward * moveAmount, moveTime).SetEase(Ease.Linear);
            yield return new WaitForSeconds(moveTime);
            transform.DORotate(transform.eulerAngles + Vector3.up * 180f, 0.3f);
            yield return new WaitForSeconds(0.3f);
            transform.DOMove(transform.position + transform.forward * moveAmount, moveTime).SetEase(Ease.Linear);
            yield return new WaitForSeconds(moveTime);
        }
        
    }
    
}
