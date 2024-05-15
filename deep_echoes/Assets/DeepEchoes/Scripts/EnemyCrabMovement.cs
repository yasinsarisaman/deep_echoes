using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyCrabMovement : MonoBehaviour
{
    [SerializeField] private float moveTime;
    [SerializeField] private float moveAmount;

    private bool _isRightMove;


    private IEnumerator Start()
    {
        while (true)
        {
            transform.DOKill(true);
            transform.DOMove(transform.position + Vector3.right * moveAmount, moveTime).SetLoops(2,LoopType.Yoyo).SetEase(Ease.Linear);
            transform.DORotate(Vector3.up * 90f, 0.3f);
            yield return new WaitForSeconds(moveTime*2+0.5f);
            transform.DOKill(true);
            transform.DOMove(transform.position + -Vector3.right * moveAmount, moveTime).SetLoops(2,LoopType.Yoyo).SetEase(Ease.Linear);
            transform.DORotate(Vector3.up * -90f, 0.3f);
            yield return new WaitForSeconds(moveTime*2+0.5f);
            transform.DOKill(true);
            transform.DOMove(transform.position + Vector3.forward * moveAmount, moveTime).SetLoops(2,LoopType.Yoyo).SetEase(Ease.Linear);
            transform.DORotate(Vector3.zero, 0.3f);
            yield return new WaitForSeconds(moveTime*2+0.5f);
            transform.DOKill(true);
            transform.DOMove(transform.position + -Vector3.forward * moveAmount, moveTime).SetLoops(2,LoopType.Yoyo).SetEase(Ease.Linear);
            transform.DORotate(Vector3.up*180f, 0.3f);
            yield return new WaitForSeconds(moveTime*2+0.5f);
        }
        
    }
    
}
