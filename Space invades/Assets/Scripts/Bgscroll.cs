using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgscroll : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private SpriteRenderer _sprite;
    [HideInInspector] private Vector2 _StartPos;
    private float _PosMinY;
    void Start(){

        _StartPos = transform.position =  new Vector2(transform.position.x, new SafeAreaData().GetMin().y);
        _PosMinY = _sprite.bounds.size.y * 2  - _StartPos.y;
    }
    void Update(){
        
        transform.Translate(translation:Vector2.down*_speed*Time.deltaTime);
        if(transform.position.y < -_PosMinY)
        {
            transform.position = _StartPos;
        }
    }

}
