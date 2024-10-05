
using System;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _rotationSpeed;



    [SerializeField]
    private float _obstacleCheckCircleRadious;
    [SerializeField]
    private float _obstacleCheckDistance;

    [SerializeField]
    private LayerMask _obstancleLayerMask;



    private Camera mainCamera;
    private Rigidbody2D _rigidbody;
    private EnemyAwakeNear _controller;

    private float ScreenBorder = -30f;

    private Vector2 _targetDirection;
    private float changeDirectionColdown = 3f;
    private RaycastHit2D[] _obstacleCollisions;

    private float _obstacleAvoidanceCooldown;
    private Vector2 _obstacleAvoidanceTargetDirection;
    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _controller = GetComponent<EnemyAwakeNear>();
        _targetDirection = transform.up;
        mainCamera = Camera.main;
        _obstacleCollisions = new RaycastHit2D[10];

    }

    private void FixedUpdate() {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection(){
        // HandleRandomDirectionChange();
        HandleTargetDirection();
        HandleObstacles();
        preventEnemyGoingOffScreen();
    }

    private void HandleObstacles()
    {
        _obstacleAvoidanceCooldown -= Time.deltaTime;

        var contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(_obstancleLayerMask);

        int numberOfCollisions = Physics2D.CircleCast(transform.position, _obstacleCheckCircleRadious, transform.up, contactFilter,_obstacleCollisions, _obstacleCheckDistance);
        // Visualize the CircleCast
        
        Debug.DrawRay(transform.position, transform.up * _obstacleCheckDistance, Color.red);
        //Dùng để vẽ đường, hướng đi của vật thể 
        for (int index = 0; index < numberOfCollisions;index ++){
            var obstacleCollision = _obstacleCollisions[index];

            
            if (obstacleCollision.collider.gameObject == gameObject){
                continue;
            }

            // if(_obstacleAvoidanceCooldown <=0 ){
            //     _obstacleAvoidanceTargetDirection = obstacleCollision.normal;
            //     _obstacleAvoidanceCooldown = 3f;

            // }
            Debug.DrawLine(transform.position,obstacleCollision.normal ,Color.blue);

            // Quaternion targetRotation = Quaternion.LookRotation(transform.up, _obstacleAvoidanceTargetDirection);
            // Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed*Time.deltaTime);

            
            _targetDirection = obstacleCollision.normal;
            //_targetDirection = rotation*Vector2.up; // hướng vuông góc với hướng đi của chính

          
            break;
        
        }


        
    
    }

    private void RotateTowardsTarget(){
        
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,Time.deltaTime*_rotationSpeed);

        _rigidbody.MoveRotation(rotation);
        
       
    }

    private void SetVelocity(){
       
        _rigidbody.velocity = _targetDirection*_speed;
        
        
    }

    private void HandleRandomDirectionChange(){
        changeDirectionColdown -= Time.deltaTime;
        if(changeDirectionColdown <=0f ){
            float angle = UnityEngine.Random.Range(-90f,90f);
            Quaternion quaternion = Quaternion.Euler(0,0,angle);
            _targetDirection = quaternion * _targetDirection;
            changeDirectionColdown = UnityEngine.Random.Range(1f,5f);

        }
    }
    private void HandleTargetDirection(){
        if(_controller.AwareOfPlayer){
            _targetDirection = _controller.DirectionToPlayer;
        }

    }

    private void preventEnemyGoingOffScreen(){
        Vector2 screenPoint = mainCamera.WorldToScreenPoint(transform.position);

        if((screenPoint.x < ScreenBorder && _targetDirection.x <0)||
            (screenPoint.x > mainCamera.pixelWidth - ScreenBorder && _targetDirection.x > 0)
        ){
            _targetDirection = _targetDirection * new Vector2(-1,1);
        }
        if((screenPoint.y < ScreenBorder && _targetDirection.y <0)||
            (screenPoint.y > mainCamera.pixelHeight - ScreenBorder && _targetDirection.y > 0)
        ){
            _targetDirection = _targetDirection * new Vector2(1,-1);
        }

    }


    public void Destroy(float time) {
        Destroy(gameObject, time);
    }
}
