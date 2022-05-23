using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shied : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D _collider2D;
    
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    private float _curretTime;
    private bool _isEnable;
    private Transform _target;
    public bool IsEnable => _isEnable;
    public void Activate(float liveTime, Transform target)
    {
       
        _curretTime += liveTime;
        if(_isEnable == false)
        {

            _target = target;
            transform.position = _target.position;
            ShowShield(true);
            StartCoroutine(Timer());
        }
    }
    private void Update()
    {
        
        if (_isEnable)
            transform.position = _target.position;
    }
    private void ShowShield(bool value)
    {
        _collider2D.enabled = value;
        _spriteRenderer.enabled = value;
        _isEnable = value;
    }

    private IEnumerator Timer()
    {
        float waitAndStep = 0.5f;

        WaitForSeconds wait = new WaitForSeconds(0.5f);

        while(_curretTime > 0)
        {
            _curretTime -= waitAndStep;
            yield return wait;
        }
        _curretTime = 0;
        ShowShield(false);
        transform.SetParent(null);
    }
}
