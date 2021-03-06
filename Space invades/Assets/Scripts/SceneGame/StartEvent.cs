using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEvent : MonoBehaviour
{
    [SerializeField]
    private GameEvent _startScene;
    [SerializeField]
    private GameEvent _gameplay;

    private void Start()
    {
        _startScene.Init();
        _gameplay.Init();
    }
}
