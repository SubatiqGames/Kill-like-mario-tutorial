using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.gameObject.GetComponent<EnemyController>();
            enemy.Kill();
        }
    }
}
