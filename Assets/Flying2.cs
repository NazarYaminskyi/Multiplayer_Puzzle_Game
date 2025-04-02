using UnityEngine;

public class Flying2 : MonoBehaviour
{
    private float startpoint = -8.645f;
    private float endpoint = -5.645f;
    [SerializeField] private float speed = 5;
    private Vector2 direction = Vector2.up;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        if (transform.position.y >= endpoint)
        {
            direction = Vector2.up; 
        }
        else if (transform.position.y <= startpoint)
        {
            direction = Vector2.down; 
        }
    }
}
