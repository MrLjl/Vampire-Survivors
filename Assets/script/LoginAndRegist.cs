using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginAndRegist : MonoBehaviour{
    private readonly string url = "http://47.92.94.83:8949/api";
    public TMP_InputField LoginAccountInput;
    public TMP_InputField LoginPasswordInput;
    public TMP_InputField RegistPasswordInput;
    public TMP_InputField RegistAccountInput;
    public void Login(){
        string account = LoginAccountInput.text;
        string password = LoginPasswordInput.text;
        if (string.IsNullOrEmpty(account)){
            Debug.LogError("´íÎó");
            return;
        }
        if (string.IsNullOrEmpty(password)){
            Debug.LogError("´íÎó");
            return;
        }
        StartCoroutine(Upload(true, account, password));
    }
    public void Resgit() {
        string account = RegistAccountInput.text;
        string password = RegistPasswordInput.text;
        if (string.IsNullOrEmpty(account))
        {
            Debug.LogError("ÕËºÅÎª¿Õ");
            return;
        }
        if (string.IsNullOrEmpty(password))
        {
            Debug.LogError("´íÎó");
            return;
        }
        StartCoroutine(Upload(false, account, password));

    }
    IEnumerator Upload(bool isLogin, string account, string pwd){
        WWWForm formData = new WWWForm();
        formData.AddField("userAccount", account);
        formData.AddField("userPwd", pwd);
        string reqUrl = isLogin ? $"{url}/login" : $"{url}/register";
        UnityWebRequest www = UnityWebRequest.Post(reqUrl, formData);
        yield return www.SendWebRequest();
        if (string.IsNullOrEmpty(www.error)){
            Debug.Log(www.downloadHandler.text);
            string json = www.downloadHandler.text;
            Response<User> response = JsonUtility.FromJson<Response<User>>(json);
            if (response.code == 200){
                SceneManager.LoadSceneAsync("MainScene");
            }
            Debug.Log(response.message);
        }
        else
            Debug.LogError(www.error);
        www.Dispose();
    }
    public void GoLogin(){
        SceneManager.LoadSceneAsync("LoginCounter");
    }
    public void ReturnRegist(){
        SceneManager.LoadSceneAsync("RegistCounter");
    }
    public void QuitGame(){
        Application.Quit();
    }
}

