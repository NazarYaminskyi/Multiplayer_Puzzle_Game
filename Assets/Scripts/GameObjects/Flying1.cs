using UnityEngine;

public class Flying1 : MonoBehaviour
{
    public float startpoint = -8.645f;
    public float endpoint = -5.645f;
    private Lever lever;
    private float speed;
    private Vector2 direction = Vector2.up;
    void Start()
    {
        lever = FindObjectOfType<Lever>();
    }
    void Update()
    {
        float speed = Mathf.Pow(lever.xPosition - 56f, 1.5f); 
        transform.Translate(direction * (speed * Time.deltaTime));
        if (transform.position.y >= endpoint)
        {
            direction = Vector2.up; 
        }
        else if (transform.position.y <= startpoint)
        {
            direction = Vector2.down; 
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player2")
        {
            Player player = other.GetComponentInParent<Player>();
            player.Death();
            Debug.Log("Destroyed!");
        }
    }
}
