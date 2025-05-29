using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using TMPro; // for TextMeshPro

public class UserAPI : MonoBehaviour
{

    [SerializeField] private GameObject playerRowPrefab;   // Single player line prefab
    [SerializeField] private Transform contentTransform;    // Content container with ScrollView
   
      private static string apiUrl = "http://192.168.1.217:5000/players";
    
    public static string GetURL() 
    {  
        return apiUrl; 
    }
 

    void Start()
    {
        StartCoroutine(GetUsers());
    }

    IEnumerator GetUsers()
    {
        if (playerRowPrefab == null || contentTransform == null)
        {
            Debug.LogError("One or more references are null.");
            yield break;
        }

        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = "{\"users\":" + request.downloadHandler.text + "}";
            PlayerModelList result = JsonUtility.FromJson<PlayerModelList>(json);
            Debug.Log("Кількість користувачів: " + result.users.Count);

            foreach (Transform child in contentTransform)
                Destroy(child.gameObject);

            foreach (var player in result.users)
            {
                Debug.Log("Creating row for: " + player.name);
                GameObject row = Instantiate(playerRowPrefab, contentTransform);

                Transform nameText = row.transform.Find("NameText");
                Debug.Log("NameText found: " + (nameText != null));
                if (nameText != null)
                    nameText.GetComponent<TMP_Text>().text = player.name;
                else
                    Debug.LogError("NameText не знайдено!");

                Transform level1Text = row.transform.Find("Level1Text");
                Debug.Log("Level1Text found: " + (level1Text != null));
                if (level1Text != null)
                    level1Text.GetComponent<TMP_Text>().text = player.level1Time;
                else
                    Debug.LogError("Level1Text не знайдено!");

                Transform level2Text = row.transform.Find("Level2Text");
                Debug.Log("Level2Text found: " + (level2Text != null));
                if (level2Text != null)
                    level2Text.GetComponent<TMP_Text>().text = player.level2Time;
                else
                    Debug.LogError("Level2Text не знайдено!");
            }
        }
        else
        {
            Debug.LogError("Помилка запиту: " + request.error);
        }
    }
}

[System.Serializable]
public class PlayerModel
{
    public int id;
    public string name;
    public string password;
    public string level1Time;
    public string level2Time;
}

[System.Serializable]
public class PlayerModelList
{
    public List<PlayerModel> users;
}
/*
 * 
*/