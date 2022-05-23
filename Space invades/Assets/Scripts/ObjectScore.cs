using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ObjectScore : MonoBehaviour
{
    public static event Action<int> OnChanged;

    [SerializeField]
    private int _score;

    public void Activate()
    {
        OnChanged?.Invoke(_score);
    }
}
