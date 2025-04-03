using UnityEngine;

public class button : MonoBehaviour
{
    public Transform door;
    public float openHeight = 3f; 
    public float moveSpeed = 2f; 

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpening = false;

    void Start()
    {
        closedPosition = door.position;
        openPosition = closedPosition + Vector3.up * openHeight;
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
            door.position = Vector3.MoveTowards(door.position, openPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            door.position = Vector3.MoveTowards(door.position, closedPosition, moveSpeed * Time.deltaTime);
        }
    }

}
