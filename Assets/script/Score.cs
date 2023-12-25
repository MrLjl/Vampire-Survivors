using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    private void Update()
    {
        scoreText.text = "µÃ·Ö£º" + PlayerManager._instance.score.ToString();
    }
}
