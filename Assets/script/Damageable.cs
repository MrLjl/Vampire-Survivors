using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField] public Health health;
    [SerializeField] public SpriteRenderer spriteRenderer;//�������ͼ�ε���ʾ
    [SerializeField] private UnityEvent damaged;

    private Color _defaultColor;//��ʼ��ɫ

    public void TakeDamage(int damage) 
    { 
        health.DecreaseHealth(damage);
        //Ѫ����ʧ������Ч
        spriteRenderer.DOColor(Color.red,0.2f).SetLoops(2,LoopType.Yoyo).ChangeStartValue(_defaultColor);

        damaged.Invoke();
    }

    private void Awake()
    {
        _defaultColor = spriteRenderer.color;
    }
}
