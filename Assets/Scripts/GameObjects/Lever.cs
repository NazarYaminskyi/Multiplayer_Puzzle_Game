using UnityEngine;

public class Lever : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Flying1 flying;
    public float xPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        xPosition = transform.position.x;
    }
}