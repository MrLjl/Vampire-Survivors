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
        var playerPosition = PlayerManager.Position;//玩家的位置
        var position = (Vector2)transform.position;//敌人的位置

        var direction = playerPosition - position;//位置
        direction.Normalize();//简化数字

        //移动的方向
        var targetPosition = position + direction;

        if (playerPosition == targetPosition)
        {
            return;
        }

        //移动方法
        rb.DOMove(targetPosition,speed).SetSpeedBased();

        moveDirection.Invoke(direction);
    }
}
