using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyFlash : MonoBehaviour
{
    [SerializeField]
    private Color targetCorlor;

    [SerializeField]
    private int numberOffFlashes;
    [SerializeField]
    private float flashDuration;

    private PlayerFlash _playerFlash;

    private void Awake() {
        _playerFlash = GetComponent<PlayerFlash>();
    }


    public void GetDamageFlash(){
        StartCoroutine(_playerFlash.FlashCoroutine(flashDuration,targetCorlor,numberOffFlashes));
    }
}
