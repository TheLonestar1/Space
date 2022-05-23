using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(Rigidbody2D))]
public class BulletMove : MonoBehaviour
{
    [SerializeField, Range(1, 35)]
    private float _speed = 5f;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.up * _speed;
    }
}
