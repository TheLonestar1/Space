using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private int _speed;
    private Rigidbody2D _ship;
    private Vector2 _moveVelocity;
    private InputPlayer _input;
    // Start is called before the first frame update
    void Start()
    {
        _speed = 4;
        _ship = GetComponent<Rigidbody2D>();
    }
    private void Awake() {
        _input = GetComponent<InputPlayer>();   
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 _moveInput = new Vector2(_input.Horizontal, _input.Vertical);
        _moveVelocity = _moveInput.normalized *_speed;

    }
    void FixedUpdate() {
        _ship.MovePosition(_ship.position + _moveVelocity * Time.fixedDeltaTime);    
    }
}
