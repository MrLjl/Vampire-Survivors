using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Image GameoverImage;
    public TMP_Text Message;
    public static GameOver _instance;
    //public Button NextLevel;
    public Button NextLevel;
    private int levelCount;
    public int CurLevel;
    private List<int> levels = new List<int>();

    private void Awake()
    {
        if (_instance != null)
            Destroy(_instance);
        _instance = this;
    }

    private void Start()
    {
        levelCount = 8;
        PlayerManager._instance.OnObjectiveComplete += _instance_OnObjectiveComplete;
    }

    private void _instance_OnObjectiveComplete()
    {
        ShowGameOver();
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Next()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0;
        GameoverImage.gameObject.SetActive(true);
        if (PlayerManager._instance.score >= 10) 
        {
            SaveLevel();
            Message.text = "Success";
            NextLevel.gameObject.SetActive(true);
        }
        else
        {
            Message.text = "GameOver";
            NextLevel.gameObject.SetActive(false);
        }
    }

    private void SaveLevel()
    {
        //Debug.Log("SaveLevel");
        //string dirPath = $"{Application.dataPath}/Data";
        //if (!Directory.Exists(dirPath))
        //    Directory.CreateDirectory(dirPath);
        //string path = $"{dirPath}/level.json";
        //if (!File.Exists(path))
        //    File.Create(path).Dispose();
        //FileStream fs = File.Open(path, FileMode.Open);
        //byte[] buffer = new byte[512];
        //fs.Read(buffer, 0, buffer.Length);
        //string json = Encoding.UTF8.GetString(buffer);
        //Debug.Log(json);
        //try
        //{
        //    Level level = JsonUtility.FromJson<Level>(json);
        //    level.takeLevels.Add(level.curLevel);
        //    byte[] bytes = Encoding.UTF8.GetBytes(JsonUtility.ToJson(level));
        //    fs.Write(bytes, 0, bytes.Length);
        //    //fs = File.Open(path, FileMode.Create);
        //    //fs.Write(bytes, 0, bytes.Length);
        //}
        //catch (ArgumentException e)
        //{
        //    Debug.LogError(e.Message); 

        //    Level level = new Level();
        //    byte[] bytes = Encoding.UTF8.GetBytes(JsonUtility.ToJson(level));
        //    fs.Write(bytes, 0, bytes.Length);
        //}

        PlayerPrefs.SetInt("Score", PlayerManager._instance.score);
        PlayerPrefs.Save();
    }

}
