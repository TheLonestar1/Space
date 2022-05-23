using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayerPosition : MonoBehaviour
{
    private const float Offset = 3f;
    private void Start()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        var positionY = new SafeAreaData().GetMin().y + Offset;
        transform.position = new Vector2(transform.position.x, positionY);
    }
}