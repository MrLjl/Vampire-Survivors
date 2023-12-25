using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField]private float speed; 
    private Vector2 _inputDirection;//�ƶ��ķ���




    //�洢��ɫ�ƶ�
    public void Move(InputAction.CallbackContext context)
    {
        _inputDirection =  context.ReadValue<Vector2>();
        //Debug.Log(_inputDirection);//����̨��ӡ����ƶ�
    }

    private void FixedUpdate()
    {
        var position = (Vector2)transform.position;//���ڵ�λ��
        var targetPositon = position + _inputDirection;//ָ��λ��

        if (position == targetPositon) {
            return;
        }

        rb.DOMove(targetPositon, speed).SetSpeedBased();//����2��ֵ��һ�����ƶ���λ�ã�һ���ǵ�ǰλ��
        
    }
}
