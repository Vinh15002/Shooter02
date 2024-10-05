using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpwaner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _collectablePrefab;

    public void Spawmcollectable(Vector2 position){
        int index = Random.Range(0, _collectablePrefab.Count);

        Instantiate(_collectablePrefab[index], position, Quaternion.identity);
    }
}
