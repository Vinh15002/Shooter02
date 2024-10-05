using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private float _minimumSpawnTime = 2f;

    [SerializeField]
    private float _maximumSpawnTime = 6f;

    private float _timeToSpawn;

    private void Awake() {
        SetTimeSpawn();
    }

    private void Update() {
        _timeToSpawn -= Time.deltaTime;
        if (_timeToSpawn < 0) {
            Instantiate(prefab,transform.position, Quaternion.identity);
            SetTimeSpawn();
        }
    }

    private void SetTimeSpawn(){
        _timeToSpawn = Random.Range(_minimumSpawnTime,_maximumSpawnTime);
    }
}
