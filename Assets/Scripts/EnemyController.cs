using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator _animator;
    private BoxCollider2D[] _colliders;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _colliders = GetComponents<BoxCollider2D>();
    }

    public void Kill()
    {
        ComplexDeath();
    }

    private void ComplexDeath()
    {
        _animator.SetTrigger("Death");

        foreach (var boxCollider2D in _colliders)
        {
            boxCollider2D.enabled = false;
        }
        
        Wait(() =>
        {
            Destroy(gameObject);
        }, 2f);
    }
    
    public void Wait(Action action, float delay)
    {
        StartCoroutine(WaitCoroutine(action, delay));
    }

    IEnumerator WaitCoroutine(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);

        action();
    }
    
}
