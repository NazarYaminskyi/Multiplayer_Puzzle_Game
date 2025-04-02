using UnityEngine;

public class Flying1 : MonoBehaviour
{
    public float startpoint = -8.645f;
    public float endpoint = -5.645f;
    [SerializeField] private float speed = 5;
    private Vector2 direction = Vector2.up;
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        if (transform.position.y <= endpoint)
        {
            direction = Vector2.up; 
        }
        else if (transform.position.y >= startpoint)
        {
            direction = Vector2.down; 
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player2")
        {
            PlayerController2DD player = other.transform.GetComponent<PlayerController2DD>();
            player.Death();
            Debug.Log("Destroyed!");
        }
    }
}
