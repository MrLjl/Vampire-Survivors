using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;//血量
    [SerializeField] private UnityEvent<int> healthChange;//血条改变

    public int value
    {
           get { return health; }  //读取血量
    }

    public void DecreaseHealth(int amount) { 
        health  -= amount;
        healthChange.Invoke(health); 
    }
}
