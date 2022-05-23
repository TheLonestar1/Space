using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody2D))]
public class MoveEnemy : MonoBehaviour
{
    private const float Speed = 2f;
    [SerializeField]
    private PathData _path;
    private int _index;
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private UnityEvent OnCheckPoint;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(Vector3.MoveTowards(transform.position, _path.Points[_index], Speed * Time.fixedDeltaTime));
        
        if(Vector3.Distance(transform.position, _path.Points[_index]) < 0.01f)
        {
            if(_index < _path.Points.Count - 1)
            {
                _index++;
                OnCheckPoint.Invoke();
            }
            else
                Destroy(gameObject);
        }
    }
}
