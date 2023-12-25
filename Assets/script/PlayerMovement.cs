using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField]private float speed; 
    private Vector2 _inputDirection;//移动的方向




    //存储角色移动
    public void Move(InputAction.CallbackContext context)
    {
        _inputDirection =  context.ReadValue<Vector2>();
        //Debug.Log(_inputDirection);//控制台打印输出移动
    }

    private void FixedUpdate()
    {
        var position = (Vector2)transform.position;//现在的位置
        var targetPositon = position + _inputDirection;//指定位置

        if (position == targetPositon) {
            return;
        }

        rb.DOMove(targetPositon, speed).SetSpeedBased();//传入2个值，一个是移动的位置，一个是当前位置
        
    }
}
