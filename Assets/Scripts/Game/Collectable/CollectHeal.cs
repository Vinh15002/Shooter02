using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHeal : MonoBehaviour, ICollectablebehaviour
{
    [SerializeField]
    private float healingAmout;

    public bool OnCollected(GameObject gameObject)
    {
        var heal = gameObject.GetComponent<healthController>();
        if (heal.PersentOfHealth < 1) {
            heal.GetHeal(healingAmout);
            return true;
        }
        else return false;
    }
}
