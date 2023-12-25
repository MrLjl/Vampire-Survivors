using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private GameObject guanka;
    [SerializeField]
    private GameObject StartGame;
    [SerializeField]
    private List<GameObject> btns;

    private void Start()
    {
        guanka.SetActive(false);

        int score = PlayerPrefs.GetInt("Score");
        int level = score / 10;
        for (int i = 0; i < btns.Count; i++)
        {
            if (i < level)
            {
                btns[i].GetComponent<Image>().color = Color.red;
                Destroy(btns[i].GetComponent<Button>());
            }
            else break;
        }
    }

    public void SelectGuanka()
    {
        guanka.SetActive(true);
        StartGame.SetActive(false);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLevel1()
    {
        SelectLevel(1);
        LoadGameScene();
    }

    public void LoadLevel2()
    {
        SelectLevel(2);
        LoadGameScene();
    }

    public void LoadLevel3()
    {
        SelectLevel(3);
        LoadGameScene();
    }
    public void LoadLevel4()
    {
        SelectLevel(4);
        LoadGameScene();
    }

    public void LoadLevel5()
    {
        LoadGameScene();
    }

    public void LoadLevel6()
    {
        LoadGameScene();
    }

    public void LoadLevel7()
    {
        LoadGameScene();
    }
    public void LoadLevel8()
    {
        LoadGameScene();
    }

    private void SelectLevel(int curLevel)
    {
        string dirPath = $"{Application.dataPath}/Data";
        if (!Directory.Exists(dirPath))
            Directory.CreateDirectory(dirPath);
        string path = $"{dirPath}/level.json";
        if (!File.Exists(path))
            File.Create(path).Dispose();
        FileStream fs = File.Open(path, FileMode.Open);
        byte[] buffer = new byte[512];
        fs.Read(buffer, 0, buffer.Length);
        string json = Encoding.UTF8.GetString(buffer);
        try
        {
            Level level = JsonUtility.FromJson<Level>(json);
            level.curLevel = curLevel;
            byte[] bytes = Encoding.UTF8.GetBytes(JsonUtility.ToJson(level));
            fs.Write(bytes, 0, bytes.Length);
        }
        catch (ArgumentException)
        {
            Level level = new Level(curLevel);
            byte[] bytes = Encoding.UTF8.GetBytes(JsonUtility.ToJson(level));
            fs.Write(bytes, 0, bytes.Length);
        }
    }
}
