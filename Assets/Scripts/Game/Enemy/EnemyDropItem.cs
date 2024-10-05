using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropItem : MonoBehaviour
{
   [SerializeField]
   private float _rateToDrop = 0.8f;

   public void OnDropItem(){
        float ran = Random.Range(0,1f);
        if(ran < _rateToDrop){
            FindAnyObjectByType<CollectableSpwaner>().Spawmcollectable(this.transform.position);
        }
   }
}
