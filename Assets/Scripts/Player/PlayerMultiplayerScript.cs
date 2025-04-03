using UnityEngine;
using Unity.Netcode;

public class PlayerMultiplayerScript : NetworkBehaviour
{
    public float moveSpeed = 5f; // Швидкість руху
    public float jumpForce = 10f; // Сила стрибка
    private bool isGrounded; // Перевірка, чи персонаж на землі

    private Rigidbody2D rb;

    public override void OnNetworkSpawn()
    {
        
        if(!IsOwner)
        {
            Destroy(this);
        }
    }
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        Move();
        Jump();
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); // Отримуємо ввід (A/D або стрілки)
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Додаємо силу стрибка
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Перевіряємо, чи доторкнулися до землі
        {
            isGrounded = true;
            Debug.Log("True");
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Перевіряємо, чи персонаж покинув землю
        {
            isGrounded = false;
            
        }
        
    }
    public void Death()
    {
        transform.position = new Vector2(20.464f, 7.656f);
    }
}
