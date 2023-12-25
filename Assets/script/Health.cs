using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;//Ѫ��
    [SerializeField] private UnityEvent<int> healthChange;//Ѫ���ı�

    public int value
    {
           get { return health; }  //��ȡѪ��
    }

    public void DecreaseHealth(int amount) { 
        health  -= amount;
        healthChange.Invoke(health); 
    }
}
