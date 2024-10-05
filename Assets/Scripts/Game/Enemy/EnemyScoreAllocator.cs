using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScoreAllocator : MonoBehaviour
{
    [SerializeField]
    private int _killScore;

    private ScoreController _controller;

    private void Awake() {
        _controller = FindAnyObjectByType<ScoreController>();

    }
    public void AllocatorScore(){
        _controller.AddScore(_killScore);
    }
}
