using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SenceFade : MonoBehaviour
{
    private Image _senceFadeImage;

    private void Awake() {
        _senceFadeImage = GetComponent<Image>();
    }

    public  IEnumerator FadeInCoroutine(float duration){
        Color startColor = new Color(0,0,0,1);
        Color targetColor = new Color(0,0,0,0);

        yield return FadeCoroutine(startColor, targetColor, duration);
        gameObject.SetActive(false);

    }

    public  IEnumerator FadeOutCoroutine(float duration){
        Color startColor = new Color(0,0,0,1);
        Color targetColor = new Color(0,0,0,0);

        gameObject.SetActive(true);
        yield return FadeCoroutine(targetColor, startColor, duration);
        

    }
    private IEnumerator FadeCoroutine(Color startColor, Color targetColor, float duration){
        float eslapsedTime  = 0f;
        float eslapsedPresentage = 0f;

        while (eslapsedTime <= duration){
            eslapsedTime += Time.deltaTime;

            eslapsedPresentage = eslapsedTime / duration;
            eslapsedPresentage = eslapsedPresentage <=1 ? eslapsedPresentage : 1;
            _senceFadeImage.color = Color.Lerp(startColor, targetColor, eslapsedPresentage);
            yield return null;
        }
    }

}
