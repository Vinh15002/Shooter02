using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlash : MonoBehaviour
{
    private SpriteRenderer _spriteRender;

    private void Awake() {
        _spriteRender = GetComponentInChildren<SpriteRenderer>();
    }


    public IEnumerator FlashCoroutine(float flashDuration, Color flashColor, int numberOffFlashes){

        Color startColor = _spriteRender.color;

        float elapsedFlashTime = 0f;
        float elapsedFlashPercentage = 0f;

        while(elapsedFlashTime < flashDuration){
            elapsedFlashTime += Time.deltaTime;
            elapsedFlashPercentage = elapsedFlashTime/flashDuration;

            elapsedFlashPercentage = elapsedFlashPercentage <= 1 ? elapsedFlashPercentage : 1;

            float pingPongPercentage = Mathf.PingPong(elapsedFlashPercentage*2*numberOffFlashes, 1);
            _spriteRender.color = Color.Lerp(startColor, flashColor,pingPongPercentage);


            yield return null;


        }


    }
}
