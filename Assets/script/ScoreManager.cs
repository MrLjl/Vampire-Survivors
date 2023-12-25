using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //单例模式，在外面调用不需要创建对象。
    public static int score = 10;
    //文本
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