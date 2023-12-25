using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Deach : MonoBehaviour
{

    [SerializeField] private UnityEvent died;

    public void CheckDeath(int health) 
    {
        if (health <= 0)
        {   
            Die();
        }
    }

    private void Die() 
    {
        Debug.Log("Dead");
        //ScoreManager.score += score1;
        gameObject.SetActive(false);
        PlayerManager._instance.score++;
        died.Invoke();
    }
}
