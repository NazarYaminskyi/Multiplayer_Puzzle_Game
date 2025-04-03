using UnityEngine;

public class button2 : MonoBehaviour
{
    public Transform door; 
    public float moveDistance = 3f; 
    public float moveSpeed = 5f; 

    private Vector3 startPosition;
    private Vector3 loweredPosition;
    private bool isOpening = false;

    void Start()
    {
        startPosition = door.position;
        loweredPosition = startPosition + Vector3.down * moveDistance; 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            isOpening = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isOpening = false;
        }
    }

    void Update()
    {
        if (isOpening)
        {
            door.position = Vector3.MoveTowards(door.position, loweredPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            door.position = Vector3.MoveTowards(door.position, startPosition, moveSpeed * Time.deltaTime);
        }
    }

}
