using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwakeNear : MonoBehaviour
{
    [SerializeField]
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float _playerAwarenessDistance;

    private Transform _player;


    private void Awake(){
        _player = FindFirstObjectByType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
       
        DirectionToPlayer = enemyToPlayerVector.normalized;
        AwareOfPlayer = _playerAwarenessDistance >= enemyToPlayerVector.magnitude;

    }
}
