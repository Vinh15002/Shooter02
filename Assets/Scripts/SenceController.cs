using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SenceController : MonoBehaviour
{
    [SerializeField]
    private float duration;

    private SenceFade _sceneFade;

    private void Awake() {
        _sceneFade = GetComponentInChildren<SenceFade>();
    }


    private IEnumerator Start() {
        yield return _sceneFade.FadeInCoroutine(duration);
    }

    public void LoadSence(string sceneName) {
        StartCoroutine(LoadSenceCoroutine(sceneName));

    }

    private IEnumerator LoadSenceCoroutine(string sceneName){
        yield return _sceneFade.FadeOutCoroutine(duration);
        yield return SceneManager.LoadSceneAsync(sceneName);
    }

}
