using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    public static PlayerManager _instance;
    public int score;
    public event Action OnObjectiveComplete;
    private bool invoked;

    public static Vector2 Position
    {
        get { return _instance.playerTransform.position; }//取得玩家的位置
    }

    private void Update()
    {
        if (!invoked && score >= PlayerPrefs.GetInt("Score") + 10) 
        {
            invoked = true;
            OnObjectiveComplete.Invoke();
        }
    }

    private void Awake()
    {
        if (_instance != null)
            Destroy(_instance);
        _instance = this;
        Time.timeScale = 1.0f;
        score = PlayerPrefs.GetInt("Score", 0);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLevel1()
    {
        GameOver._instance.CurLevel = 1;
        LoadGameScene();
    }

    public void LoadLevel2()
    {
        GameOver._instance.CurLevel = 2;
        LoadGameScene();
    }

    public void LoadLevel3()
    {
        GameOver._instance.CurLevel = 3;
        LoadGameScene();
    }
    public void LoadLevel4()
    {
        GameOver._instance.CurLevel = 2;
        LoadGameScene();
    }

    public void LoadLevel5()
    {
        GameOver._instance.CurLevel = 1;
        LoadGameScene();
    }

    public void LoadLevel6()
    {
        GameOver._instance.CurLevel = 2;
        LoadGameScene();
    }

    public void LoadLevel7()
    {
        GameOver._instance.CurLevel = 3;
        LoadGameScene();
    }
    public void LoadLevel8()
    {
        GameOver._instance.CurLevel = 2;
        LoadGameScene();
    }
}
