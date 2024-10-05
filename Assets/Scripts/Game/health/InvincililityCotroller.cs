using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincililityCotroller : MonoBehaviour
{
    [SerializeField]
    private float _invincibleDuration = 3f;
    private healthController _healthController;
    private PlayerFlash _spriteFlash;

    [SerializeField] 
    private Color flashColor;

    [SerializeField]
    private int numOffFlashed;

    private void Awake() {
        _healthController = GetComponent<healthController> ();
        _spriteFlash = GetComponent<PlayerFlash> ();    
    }

    public void Startinvincibility(){
        StartCoroutine(InvincibityCoroutine(_invincibleDuration, flashColor, numOffFlashed));
    }

    private IEnumerator InvincibityCoroutine(float _invincibleDuration, Color flashColor, int numOffFlashed){
        _healthController.IsVincible = true;
        //yield return new WaitForSeconds(_invincibleDuration);
        yield return _spriteFlash.FlashCoroutine(_invincibleDuration, flashColor, numOffFlashed); 
        _healthController.IsVincible = false;
    }

}
