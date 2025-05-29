using UnityEngine.Networking;
using UnityEngine;
using System.Collections;


public class UIFUN
{
    private string baseApiUrl = UserAPI.GetURL();

    public IEnumerator CreateUser(string name, string password)
    {
        UserCreateRequest data = new UserCreateRequest
        {
            name = name,
            password = password
        };

        string json = JsonUtility.ToJson(data);
        UnityWebRequest request = new UnityWebRequest(baseApiUrl, "POST");

        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Користувач створений: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Помилка створення користувача: " + request.error);
        }
    }

    public IEnumerator UpdateLevelTime(int userId, int levelNumber, string time)
    {
        LevelUpdateRequest data = new LevelUpdateRequest
        {
            level = levelNumber,
            time = time
        };

        string json = JsonUtility.ToJson(data);
        UnityWebRequest request = new UnityWebRequest(baseApiUrl + $"/users/{userId}/level", "PUT");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Час оновлено: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Помилка оновлення часу: " + request.error);
        }
    }

    [System.Serializable]
    public class UserCreateRequest
    {
        public string name;
        public string password;
    }

    [System.Serializable]
    public class LevelUpdateRequest
    {
        public int level;
        public string time;
    }
}