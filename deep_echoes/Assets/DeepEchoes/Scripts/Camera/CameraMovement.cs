using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player; 
    [SerializeField] private float _camSpeed;
    private static readonly Matrix4x4 _matrice = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    
    private float offsetX = 0;


    void Update()
    {
        /* TODO remove copying every time  */
        var skewedInput = _matrice.MultiplyPoint3x4(_player.transform.localPosition);
        transform.localPosition = new Vector3(-1 * skewedInput.z, 0, -30);

    }

}
