using System;
using System.Collections;
using System.Collections.Generic;
using Timers;
using UnityEngine;
using UnityEngine.Events;

public class MagicMissile : MonoBehaviour
{
    [SerializeField] private MissileCreator creator;
    [SerializeField] private UnityEvent missileLaunch;

    private void LaunchMissile() 
    {
        Debug.Log("Attack");
        creator.CreatMissile();
        missileLaunch.Invoke();
    }

    private void Awake()
    {
        // LaunchMissile();
        //TimersManager.SetLoopableTimer(this,1, LaunchMissile);
    }

    private void Update()
    {
        CheckAttack();
    }

    /// <summary>
    /// ºÏ≤È∞¥º¸ ‰»Î£¨Attack
    /// </summary>
    private void CheckAttack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            LaunchMissile();
        }
    }

}
