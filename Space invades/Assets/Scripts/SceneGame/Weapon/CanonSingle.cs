using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonSingle : CannonBase
{
    [SerializeField]
    private Transform _bulletStartPosition;
    
    public override void Shot()
    {
        BulletActivate(_bulletStartPosition);
    }
}
