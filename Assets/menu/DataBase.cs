using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class UserAPI : MonoBehaviour
{
    [SerializeField] private GameObject userTextPrefab;  // text prefab
    [SerializeField] private Transform contentTransform; // Content зі ScrollView


    private string apiUrl = "http://localhost:5000/players"; // або /players http://localhost:5000/players


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
                text.text = $"Ім'я: {user.Name} | Рівень 1: {user.Level1Time} | Рівень 2: {user.Level2Time}";

            }
        }
        else
        {
            Debug.LogError("Помилка запиту: " + request.error);
        }
    }
}

