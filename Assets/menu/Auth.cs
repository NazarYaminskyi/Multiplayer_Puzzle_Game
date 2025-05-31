using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class AuthManager : MonoBehaviour
{
    public InputField NameInput;
    public InputField PaswordInput;

    private string apiUrl = "http://192.168.1.217:5000/players";

    public void OnRegisterClick()
    {
        StartCoroutine(RegisterUser());
    }

    public void OnLoginClick()
    {
        StartCoroutine(LoginUser());
    }

    IEnumerator RegisterUser()
    {
        PlayerModel player = new PlayerModel
        {
            Name = NameInput.text,
            Password = PaswordInput.text,
            Level1Time = "",
            Level2Time = ""
        };

        string jsonData = JsonUtility.ToJson(player);
        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("���������� �������������!");
        }
        else
        {
            Debug.LogError("������� ���������: " + request.error);
        }
    }

    IEnumerator LoginUser()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = "{\"users\":" + request.downloadHandler.text + "}";
            PlayerModelList result = JsonUtility.FromJson<PlayerModelList>(json);

            bool found = false;

            foreach (var user in result.users)
            {
                if (user.Name == NameInput.text && user.Password == PaswordInput.text)
                {
                    found = true;
                    break;
                }
            }

            if (found)
            {
                Debug.Log("���� �������!");
                // ��� ����� ����������� ����� ��� �������� PlayerPrefs
            }
            else
            {
                Debug.Log("������ ��� ��� ������");
            }
        }
        else
        {
            Debug.LogError("������� ������: " + request.error);
        }
    }
}
