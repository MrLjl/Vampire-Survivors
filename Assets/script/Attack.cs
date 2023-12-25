using System;
using System.Collections;
using System.Collections.Generic;
using Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{

    [SerializeField] private string targetTag;

    [SerializeField] private UnityEvent attack;

    private bool _canAttack = true;
    private void OnTriggerEnter2D(Collider2D col)
    {
        DealDamage(col);
    }

    private void canAttack()
    {
        _canAttack = true;
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        DealDamage(other);
    }

    private void DealDamage(Collider2D other) {
        if (!_canAttack) return;
        //第一步 检查被撞的是不是玩家
        if (other.CompareTag(targetTag))
        {
            var damageable = other.GetComponent<Damageable>();
            damageable.TakeDamage(1);
            TimersManager.SetTimer(this, 1, canAttack);
            _canAttack = false;

            attack.Invoke();
        }
    }
}
