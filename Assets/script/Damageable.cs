using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField] public Health health;
    [SerializeField] public SpriteRenderer spriteRenderer;//控制玩家图形的显示
    [SerializeField] private UnityEvent damaged;

    private Color _defaultColor;//初始颜色

    public void TakeDamage(int damage) 
    { 
        health.DecreaseHealth(damage);
        //血条消失术的特效
        spriteRenderer.DOColor(Color.red,0.2f).SetLoops(2,LoopType.Yoyo).ChangeStartValue(_defaultColor);

        damaged.Invoke();
    }

    private void Awake()
    {
        _defaultColor = spriteRenderer.color;
    }
}
