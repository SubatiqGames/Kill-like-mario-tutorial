using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float jumpHeight = 6;
    private Animator _animator;
    private bool _grounded = false;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Move(1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(-1);
        }

        _animator.SetBool("is Walking", !(Mathf.Abs(_rb.velocity.x) < 1 && _grounded));

        if (!_grounded)
        {
            _animator.SetBool("is Walking", false);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (!_grounded && _rb.velocity.y < jumpHeight/4)
        {
            _rb.AddForce(new Vector2(0, -jumpHeight/6), ForceMode2D.Impulse);
        }
    }

    private void Move(int direction)
    {
        _rb.velocity = new Vector2(direction * speed, _rb.velocity.y);
        transform.localScale = new Vector3(direction, 1, 1) * transform.localScale.y;
    }

    public void Jump()
    {
        if (_grounded)
            _rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _grounded = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _grounded = false;
        }
    }
}
