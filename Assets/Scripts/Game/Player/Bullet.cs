using System;
using System.Collections;
using System.Collections.Generic;

using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _timeToDestroy = 10f;

    [SerializeField]
    private float _speed = 5f; 
    private Rigidbody2D _rigibody;

    private Vector2 _direction;

    private Camera main_camera;
    private void Awake() {
        _rigibody = GetComponent<Rigidbody2D>();
        _direction = PlayerMovement.instance.transform.up;
        main_camera = Camera.main;
        Invoke("OnDestroy",_timeToDestroy);
    }
    private void FixedUpdate() {
        DestroyWhenOutOfScreen();   
        _rigibody.velocity = _speed * _direction;
    }

    private void OnDestroy() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("enemy")){
            other.gameObject.GetComponent<healthController>().TakeDamage(10f);

            Destroy(gameObject);

        }
    }

    private void DestroyWhenOutOfScreen(){
        Vector2 screenPoint = main_camera.WorldToScreenPoint(transform.position);
        if(screenPoint.x < 0 || screenPoint.y < 0 || screenPoint.x > main_camera.pixelWidth || main_camera.pixelWidth < screenPoint.y){
            Destroy(gameObject);
        }
    }
}
