using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //����ģʽ����������ò���Ҫ��������
    public static int score = 10;
    //�ı�
    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }
}