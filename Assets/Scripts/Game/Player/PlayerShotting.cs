using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShotting : MonoBehaviour
{

    [SerializeField]
    private GameObject _bulletPrefab;


    [SerializeField]
    private float _bulletSpeed;


    private bool _fireContinuously;

    [SerializeField]
    private float _timeshot = 0.5f ;
    private float _timebetweenshots;
    void Update()
    {
        if (_fireContinuously && _timebetweenshots <= 0.0001f){
            FireBullet();
            _timebetweenshots = _timeshot;
        }
        _timebetweenshots -= Time.deltaTime;
    }

    private void FireBullet()
    {
        Transform getGunOffset = transform.GetChild(1).transform;
        Instantiate(_bulletPrefab, getGunOffset.position, transform.rotation); 
    }

    public void OnFire(InputAction.CallbackContext callbackContext){
        _fireContinuously = callbackContext.performed;
        // if(callbackContext.started){
        //     Instantiate(_bulletPrefab,transform.position, transform.rotation);
        //     // Debug.Log("TANG TANG");
        // }
    }
}
