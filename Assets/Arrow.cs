using UnityEngine;
using System.Collections;
public class Arrow : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject prefab;
    private GameObject currentObject;
    public Vector2 startposition;
    public float delayTime = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
    //     CreateObject();
    // }
    // void CreateObject()
    // {
    //     currentObject = Instantiate(prefab, startposition, Quaternion.identity);
        
    //     Invoke(nameof(DestroyAnd), delayTime);
    // }

    // // Update is called once per frame
    // void DestroyAnd()
    // {
    //     transform.Translate(Vector2.up * speed * Time.deltaTime);
    //     // if(transform.position.y==-8.645f)
    //     // {
    //     Destroy(prefab);
    //     CreateObject();
    //         //Instantiate(prefab, new Vector2(-4.386899f, 4.491219f), Quaternion.identity);
    //     //}
    // }
    // void Start()
    // {
    //     // Запустити цикл створення і видалення об'єктів
    //     StartCoroutine(CycleObject());
    // }

    // IEnumerator CycleObject()
    // {
    //     while (true)
    //     {
    //         // Створення об'єкта
    //         currentObject = Instantiate(prefab, startposition, Quaternion.identity);

    //         // Зачекати задану кількість секунд
    //         yield return new WaitForSeconds(delayTime);

    //         // Знищення об'єкта
    //         Destroy(currentObject);

    //         // Зачекати перед наступним створенням
    //         yield return new WaitForSeconds(delayTime);
    //     }
    // }
    void Start()
    {

    }
    void Update()
    {
        currentObject = Instantiate(prefab, startposition, Quaternion.identity);
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Destroy(currentObject, delayTime);
    }
}
