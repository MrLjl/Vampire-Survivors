using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManger : MonoBehaviour
{
    public void Stop()
    {
       Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
}
