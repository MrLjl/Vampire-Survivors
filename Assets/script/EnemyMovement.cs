using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    //[SerializeField] private PlayerManager playerManager; 
    [SerializeField] private UnityEvent<Vector2> moveDirection; 


    public void FixedUpdate()
    {
        var playerPosition = PlayerManager.Position;//��ҵ�λ��
        var position = (Vector2)transform.position;//���˵�λ��

        var direction = playerPosition - position;//λ��
        direction.Normalize();//������

        //�ƶ��ķ���
        var targetPosition = position + direction;

        if (playerPosition == targetPosition)
        {
            return;
        }

        //�ƶ�����
        rb.DOMove(targetPosition,speed).SetSpeedBased();

        moveDirection.Invoke(direction);
    }
}
