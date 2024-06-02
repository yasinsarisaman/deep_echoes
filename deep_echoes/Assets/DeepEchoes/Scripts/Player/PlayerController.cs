using System;
using System.Collections;
using System.Collections.Generic;
using DeepEchoes.Scripts.Events;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rbody;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private Animator animator;
    
    private Vector3 movementInput;
    private static readonly int _isWalking = Animator.StringToHash("isWalking");

    public static PlayerController Instance { get; private set; }

    private void Awake() 
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    
    private void OnEnable()
    {
        EventBus<ApplyDamageEvent>.AddListener(OnApplyDamageEvent);
    }

    private void OnDisable()
    {
        EventBus<ApplyDamageEvent>.AddListener(OnApplyDamageEvent);
    }

    private void OnApplyDamageEvent(object sender, ApplyDamageEvent e)
    {
        transform.DOKill(true);
        transform.DOPunchScale(Vector3.one*0.3f, 0.1f);
    }

    private void Update()
    {
        Look();
    }


    public void FixedUpdate()
    {
        Move();
        //movementInput = Vector3.zero;
    }

    /* Runs when the any of movement inputs triggered */
    public void MovementTrigger(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        movementInput = new Vector3(input.x, 0, input.y);
        
    }

    public void Look()
    {
        if (movementInput != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
            var skewedInput = matrix.MultiplyPoint3x4(movementInput);
            var relative = (transform.position + skewedInput) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }
    }

    public void Move()
    {
        var movementInputMagnitude = movementInput.magnitude;
        animator.SetBool(_isWalking, movementInputMagnitude > 0);
        rbody.MovePosition(transform.position + transform.forward * (movementInputMagnitude * speed * Time.deltaTime));
    }

    public void PushBack(Vector3 target)
    {
        rbody.isKinematic = true;
        var backVector = transform.position - target;
        backVector.y = 0;
        transform.DOJump( transform.position +backVector.normalized * 4f, 1.5f,1,0.2f);
        Invoke(nameof(EnableRigid),0.2f);
    }

    private void EnableRigid()
    {
        rbody.isKinematic = false;
    }
}
