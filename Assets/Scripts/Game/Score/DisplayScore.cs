using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    private TMP_Text text;

    private void Awake() {
        text = GetComponent<TMP_Text>();
    }

    public void OnChangeScore(int score){
        text.text = $"Score: {score}";
    }

}
