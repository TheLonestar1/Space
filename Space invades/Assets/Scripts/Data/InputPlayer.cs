using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public bool isFire {get; private set;}
    public float Horizontal {get; private set;}
    public float Vertical {get; private set;}

    public event Action Fired = default;
    private void Update()
    {
        isFire = Input.GetButtonDown("Fire1");
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        if(isFire && Fired != null)
        {
            Fired();
        }
    }
}
