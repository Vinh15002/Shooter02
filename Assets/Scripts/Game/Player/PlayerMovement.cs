using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour

{

    
    [SerializeField]
    private float ScreenBorder = 100f;

    private Animator animator;
    public static PlayerMovement instance;
    private bool _rotate;

    private Camera mainCamera;
    public Rigidbody2D _rigidbody;
    public Vector2 _movementInput;

    private Vector3 _mouseDirection;
    public bool _isrunning = false;
    public bool IsRunning {
        get {return _isrunning;}
        set {
            _isrunning = value;
            animator.SetBool("IsRunning", _isrunning);
        }
    }
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    [SerializeField]
    public float speed = 2f;
    public bool isDashing = false;

    private void Awake() {
        PlayerMovement.instance = this;
        _rigidbody = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        animator = transform.GetChild(0).GetComponent<Animator>();

    }

    private void FixedUpdate()
    {   
        
        
        getMousePosition();
        RotateInDirectionOfInput();

        if(isDashing) return;
        SetVelocCity();
       
    }


    private void getMousePosition()
    {
        _mouseDirection = mainCamera.ScreenToWorldPoint(Input.mousePosition);

       
    }

    private void RotateInDirectionOfInput()
    {
       

       
        Vector3 rotation = _mouseDirection - transform.position;


        float rotZ = Mathf.Atan2(rotation.y, rotation.x)*Mathf.Rad2Deg - 90;
       

        transform.rotation = Quaternion.Euler(0,0,rotZ);
        
    }

    private void SetVelocCity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _movementInputSmoothVelocity,
            0.1f
        );
        
        _rigidbody.velocity = _smoothedMovementInput * speed;
        PreventPlayerGoingOffScreen();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
        IsRunning = _movementInput != Vector2.zero;
        
    }
    private void PreventPlayerGoingOffScreen(){
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);

        if((screenPosition.x < ScreenBorder && _rigidbody.velocity.x <0)||
            (screenPosition.x > mainCamera.pixelWidth -ScreenBorder && _rigidbody.velocity.x > 0)
        ){
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocityY);
        }
        if ((screenPosition.y < ScreenBorder && _rigidbody.velocityY <0)||
                 (screenPosition.y > mainCamera.pixelHeight -ScreenBorder && _rigidbody.velocity.y > 0)
        ){
            _rigidbody.velocity = new Vector2(_rigidbody.velocityY,0);
        }
    }

    public void OnExit(InputAction.CallbackContext callbackContext){
        if (callbackContext.started)
        {
            Application.Quit();    

        }
    }





}

    

