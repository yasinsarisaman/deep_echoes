using System;
using System.Collections;
using System.Collections.Generic;
using DeepEchoes.Scripts.Environment;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var interactObj = other.GetComponent<IInteractable>();
        interactObj?.Interact();
    }
}
