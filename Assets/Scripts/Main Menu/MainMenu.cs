using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private SenceController senceController;
    private void Awake() {
        senceController = FindAnyObjectByType<SenceController>();
    }
    
    public void Play(){
        senceController.LoadSence("Game");
    }

    public void Exit(){
        Application.Quit();
    }
}
