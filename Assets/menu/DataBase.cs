using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class UserAPI : MonoBehaviour
{
    [SerializeField] private GameObject userTextPrefab; // �� ���� ��� ��������� ������
    [SerializeField] private Transform contentTransform; // �� Content � ScrollView


private string apiUrl = "http://192.168.1.243:5000/users";

    void Start()
    {
        StartCoroutine(GetUsers());
    }

    IEnumerator GetUsers()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = "{\"users\":" + request.downloadHandler.text + "}";
            PlayerModelList result = JsonUtility.FromJson<PlayerModelList>(json);

            foreach (Transform child in contentTransform)
            {
                Destroy(child.gameObject);
            }

            foreach (var user in result.users)
            {
                GameObject obj = Instantiate(userTextPrefab, contentTransform);
                TMPro.TextMeshProUGUI text = obj.GetComponent<TMPro.TextMeshProUGUI>();
                text.text = $"��'�: {user.name} | �������: {user.progress}";
            }
        }
        else
        {
            Debug.LogError("������� ������: " + request.error);
        }
    }
}

[System.Serializable]
public class PlayerModel
{
    public int id;
    public string name;
    public string password;
    public int progress;
}

[System.Serializable]
public class PlayerModelList
{
    public List<PlayerModel> users;
}