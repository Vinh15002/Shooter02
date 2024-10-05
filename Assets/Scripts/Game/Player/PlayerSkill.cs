using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSkill : MonoBehaviour
{

    [SerializeField]
    private GameObject playerGhostPrefab;

    [SerializeField]
    private float dashBoost = 10f;
    [SerializeField]
    private float dashDuration = 0.2f;

    [SerializeField]
    private float cooldownDash = 1f;

    private Boolean canDash = true;
    private Rigidbody2D _rigidbody;
   
    private float _timeDash = 0;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        
        
    }

    public IEnumerator Dash(){
        Vector2 veclocityDash = new Vector2(_rigidbody.velocityX*dashBoost, _rigidbody.velocityY*dashBoost);
        while(_timeDash <= dashDuration){
            PlayerMovement.instance.isDashing = true;
            _rigidbody.velocity =veclocityDash;
            GameObject ghost = Instantiate(playerGhostPrefab, transform.position, transform.rotation);
           
            _timeDash += Time.deltaTime;
            yield return null;
            Destroy(ghost,0.5f);
        }
        
        PlayerMovement.instance.isDashing = false;
        canDash = false;
        _timeDash = 0;
        yield return new WaitForSeconds(cooldownDash);
        canDash = true;



    }

  
    public void onDash(InputAction.CallbackContext callbackContext){
        if(!PlayerMovement.instance.isDashing && canDash){
            StartCoroutine(Dash());
        }
        
    }

}
