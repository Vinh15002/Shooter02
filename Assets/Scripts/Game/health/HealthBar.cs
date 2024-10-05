using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHealth3 : MonoBehaviour
{
    private Image img;
    private void Awake() {
        img = GetComponent<Image>();
    }
    public void UpdateHealthBar(float PersentOfHealth){
        img.fillAmount = PersentOfHealth;
    }
}
