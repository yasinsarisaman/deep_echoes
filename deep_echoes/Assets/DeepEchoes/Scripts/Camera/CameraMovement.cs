using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player; 
    [SerializeField] private float _camSpeed;
    
    private float offsetX = 0;


    void Update()
    {
        // if (_player.transform.position.x > _cameraThresholdX || _player.transform.position.x < (-1*_cameraThresholdX))
        // {
        //     offsetX += _cameraThresholdX - _player.transform.position.x;
        // }
        
    }

    private void LateUpdate()
    {        
        transform.localPosition = new Vector3(_player.transform.position.x, 0, -30);
        // TODO add interpolation with speed - YASIN...
        // TODO fix cam movement 
    }
}
