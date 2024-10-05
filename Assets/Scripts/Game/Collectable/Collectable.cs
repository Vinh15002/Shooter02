using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private ICollectablebehaviour _collectablebehaviour;

    private void Awake() {
        _collectablebehaviour = GetComponent<ICollectablebehaviour>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            if(_collectablebehaviour.OnCollected(other.gameObject)) 
                Destroy(gameObject);
        }
    }
}
