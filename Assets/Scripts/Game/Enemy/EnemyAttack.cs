using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float _damageAmout = 10f;

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<healthController>().TakeDamage(_damageAmout);
        }
    }
}
